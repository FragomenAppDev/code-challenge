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

        public QuotesController()
        {
            quoteRepository.CreatePairsDataStruct();
        }

        // GET api/quotes
        [HttpGet]
        public IEnumerable<Quote> Get()
        {
            return quoteRepository.GetAll();
        }

        // GET api/quotes/5
        [HttpGet("{id:long}")]
        public IActionResult Get(long id)
        {
            Quote quote = quoteRepository.GetById(id);
            if (quote != null)
            {
                return Ok(quote);
            }
            else
            {
                return NotFound();
            }
        }

        // GET api/quotes/pairs/20
        [HttpGet("pairs/{length:long}")]
        public long GetPairs(long length)
        {
            return quoteRepository.GetNumberOfPairs(length);
        }

        // POST api/quotes
        [HttpPost]
        public IActionResult Post([FromBody] Quote user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(quoteRepository.Create(user));
        }

        // PUT api/quotes/5
        [HttpPut("{id:long}")]
        public IActionResult Put(long id, [FromBody] Quote user)
        {
            if(user == null) 
            {
                return BadRequest();
            }
            if(quoteRepository.Update(id, user) != null)
            {
                return Ok();
            }
            else 
            {
                return NotFound();
            }
        }

        // DELETE api/quotes/5
        [HttpDelete("{id:long}")]
        public IActionResult Delete(long id)
        {
            if(quoteRepository.Delete(id))
            {
                return Ok();
            }
            else 
            {
                return NotFound();
            }
        }     
    }
}
