using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.DTOs.Options;
using QuizAPI.DTOs.Questions;
using QuizAPI.DTOs.Quizzes;
using QuizAPI.Entities;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public QuizController(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        // GET: api/Quiz
        [HttpGet]
        public IActionResult Get()
        {
            var quizDbo = _dbContext.Quizzes
                .Select(x => _mapper.Map(x, new QuizGetDbo()
                {
                    Name = x.Name,
                    CreationDate = x.CreationDate
                }))
                .AsNoTracking()
                .ToList();

            return Ok(quizDbo);

        }

        // GET: api/Quiz/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var quiz = _dbContext.Quizzes.Include(x => x.questions)
                .ThenInclude(x => x.options)
                .FirstOrDefault(x => x.Id == id);
            if (quiz is null) return NotFound();

            var dbo = new QuizDetailedGetDbo();
            _mapper.Map(quiz, dbo);

            return Ok(dbo);
        }

        // POST: api/Quiz
        [HttpPost]
        public IActionResult Post([FromBody] QuizPostDbo quizPostDbo)
        {

            var quiz = _mapper.Map<Quiz>(quizPostDbo);

            _dbContext.Quizzes.Add(quiz);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Post), new { id = quiz.Id });
        }
        //var quizEntity = _mapper.Map<Quiz>(quizPostDbo);

        //quizEntity.questions ??= new List<Question>();
        // PUT: api/Quiz/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] QuizPutDbo dbo)
        {
            var quiz = _dbContext.Quizzes.FirstOrDefault(x => x.Id == id);
            if (quiz is null) return NotFound();

            _mapper.Map(dbo, quiz);

            _dbContext.SaveChanges();
            return Ok(quiz.Id);
        }

        // DELETE: api/Quiz/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var quiz = _dbContext.Quizzes.FirstOrDefault(x => x.Id == id);
            if (quiz is null) return NotFound();

            _dbContext.Remove(quiz);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
