using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using QuizAPI.Data;
using QuizAPI.DTOs.Options;
using QuizAPI.Entities;

namespace QuizAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public OptionController(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        // GET: api/Option
        [HttpGet]
        public IActionResult Get()
        {
            var option = _dbContext.Options.AsNoTracking().ToList();

            var opt = new List<OptionGetDbo>();
            _mapper.Map(option, opt);

            return Ok(opt);
        }

        // GET: api/Option/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var option = _dbContext.Options.FirstOrDefault(x => x.Id == id);
            if (option is null) return NotFound();

            var opt = new OptionGetDbo();
            _mapper.Map(option, opt);

            return Ok(opt);
        }

        // POST: api/Option
        [HttpPost]
        public IActionResult Post([FromBody] OptionPostDbo postDbo)
        {
            var option = new Option();
            _mapper.Map(postDbo, option);

            _dbContext.Add(option);
            _dbContext.SaveChanges();


            return Ok(option.Id);
        }

        // PUT: api/Option/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] OptionPutDbo dbo)
        {
            var option = _dbContext.Options.FirstOrDefault(x => x.Id == id);
            if (option is null) return NotFound();

            _mapper.Map(dbo, option);

            _dbContext.SaveChanges();

            return Ok(option.Id);
        }

        // DELETE: api/Option/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var option = _dbContext.Options.FirstOrDefault(x => x.Id == id);
            if (option is null) return NotFound();

            _dbContext.Remove(option);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
