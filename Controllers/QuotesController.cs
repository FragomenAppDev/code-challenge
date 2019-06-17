using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeChallenge.Model;

namespace CodeChallenge.Controllers
{
    [Route("api/[controller]")]
    public class QuotesController : ControllerBase
    {
        // GET api/quotes
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/quotes/5
        [HttpGet("{id}")]
        public Quote Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/quotes
        [HttpPost]
        public long Post([FromBody] Quote user)
        {
            throw new NotImplementedException();
        }

        // PUT api/quotes/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Quote user)
        {
            throw new NotImplementedException();
        }

        // DELETE api/quotes/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            throw new NotImplementedException();
        }     
    }
}
