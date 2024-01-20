using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.DTOs.Questions;
using QuizAPI.Entities;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public QuestionController(AppDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        // GET: api/Question
        [HttpGet]
        public IActionResult Get()
        {
            var question = _dbContext.Questions
                .Include(x => x.options)
                .Select(x => _mapper.Map(x, new QuestionGetDbo()))
                .AsNoTracking()
                .ToList();


            return Ok(question);
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var question = _dbContext.Questions
                .Include(x => x.options)
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            var dbo = new QuestionGetDbo();
            _mapper.Map(question, dbo);

            return Ok(dbo);
        }

        // POST: api/Question
        [HttpPost]
        public IActionResult Post([FromBody] QuestionPostDbo postDbo)
        {
            //var option = _dbContext.Options.FirstOrDefault(x => x.Id == postDbo.);
            //if (option is null) return NotFound();

            var question = new Question()
            {
                QuestionName = postDbo.Name,
                Points = postDbo.Points,
            };

            _mapper.Map(postDbo, question);

            _dbContext.Add(question);
            _dbContext.SaveChanges();

            return Ok(question.Id);

        }

        // PUT: api/Question/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] QuestionPutDbo putDbo)
        {
            var question = _dbContext.Questions.FirstOrDefault(x => x.Id == id);
            if (question is null) return NotFound();

            _mapper.Map(putDbo, question);

            _dbContext.SaveChanges();

            return Ok(question.Id);
        }

        // DELETE: api/Question/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var question = _dbContext.Questions.FirstOrDefault(x => x.Id == id);
            if (question is null) return NotFound();

            _dbContext.Remove(question);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
