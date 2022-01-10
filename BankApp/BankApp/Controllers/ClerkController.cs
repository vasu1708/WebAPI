using BankApp.Models;
using BankApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClerkController : ControllerBase
    {
        ClerkService clerkService;
        public ClerkController()
        {
            clerkService = new ClerkService();
        }
        // GET: api/<ClerkController>
        [HttpGet("{bankId}")]
        public ActionResult<List<Clerk>> GetAll(string bankId) => clerkService.GetAllClerks(bankId);

        // GET api/<ClerkController>/5
        [HttpGet("{bankId}/{clerkId}")]
        public ActionResult<Clerk> Get(string bankId,string clerkId)
        {
            var result = clerkService.CheckClerk(bankId, clerkId);
            if (result != null)
                return NotFound(result);
            return Ok(clerkService.GetClerk(bankId, clerkId));
        }

        // POST api/<ClerkController>
        [HttpPost("{bankId}")]
        public IActionResult Post(string bankId,Clerk clerk)
        {
            var result = clerkService.Check(bankId);
            if (result != null)
                return NotFound(result);
            else if (bankId != clerk.BankId)
                return BadRequest("Bad request! recheck the bank-id");
            clerkService.AddClerk(bankId, clerk);
            return CreatedAtAction(nameof(Post), new { clerkId = clerk.ClerkId }, clerk);
        }

        // PUT api/<ClerkController>/5
        [HttpPut("{bankId}/{clerkId}")]
        public IActionResult Put(string bankId,string clerkId, Clerk clerk)
        {
            var result = clerkService.CheckClerk(bankId,clerkId);
            if (result != null)
                return NotFound(result);
            else if (bankId != clerk.BankId || clerkId != clerk.ClerkId)
                return BadRequest("Bad request! recheck the bank-id & clerk-id");
            clerkService.UpdateClerk(bankId,clerkId,clerk);
            return Ok("Success!");
        }

        // DELETE api/<ClerkController>/5
        [HttpDelete("{bankId}/{clerkId}")]
        public IActionResult Delete(string bankId,string clerkId)
        {
            var result = clerkService.CheckClerk(bankId, clerkId);
            if (result != null)
                return NotFound(result);
            clerkService.DeleteClerk(bankId,clerkId);
            return Ok("Success!");
        }
    }
}
