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
            var clerk = clerkService.GetClerk(bankId, clerkId);
            if(clerk == null)
                return NotFound();
            return Ok(clerk);
        }

        // POST api/<ClerkController>
        [HttpPost("{bankId}")]
        public IActionResult Post(string bankId,Clerk clerk)
        {
            if (clerkService.GetBank(bankId) == null)
                return NotFound("Bank not found with that id");
            clerkService.AddClerk(bankId,clerk);
            return CreatedAtAction(nameof(Post), new { clerkId = clerk.ClerkId }, clerk);
        }

        // PUT api/<ClerkController>/5
        [HttpPut("{bankId}/{clerkId}")]
        public IActionResult Put(string bankId,string clerkId, Clerk clerk)
        {
            if (clerkService.GetClerk(bankId, clerkId) == null || clerkId != clerk.ClerkId)
                return NotFound("Not Found! Recheck your bank-id and clerk-id");
            clerkService.UpdateClerk(clerkId,clerk);
            return Ok("Success!");
        }

        // DELETE api/<ClerkController>/5
        [HttpDelete("{bankId}/{clerkId}")]
        public IActionResult Delete(string bankId,string clerkId)
        {
            if (clerkService.GetClerk(bankId, clerkId) == null)
                return NotFound("Not Found! Recheck your bank-id and clerk-id");
            clerkService.DeleteClerk(bankId,clerkId);
            return Ok("Success!");
        }
    }
}
