using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Model;
using CodeChallenge.Repository;

namespace CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        private QuoteRepository quoteRepository = new QuoteRepository();

        // GET api/quotes
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return quoteRepository.GetAll();
        }

        // GET api/quotes/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            return quoteRepository.GetById(id);
        }

        // POST api/quotes
        [HttpPost]
        public long Post([FromBody] Quote user)
        {
            return quoteRepository.Create(user);
        }

        // PUT api/quotes/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Quote user)
        {
            quoteRepository.Update(id, user);
        }

        // DELETE api/quotes/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            quoteRepository.Delete(id);
        }     
    }
}
