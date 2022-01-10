using BankApp.Models;
using BankApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        ClerkService clerkService;
        public BankController()
        {
            clerkService = new ClerkService();
        }
        // GET: api/<BankController>
        [HttpGet]
        public ActionResult<List<Bank>> GetAll() => clerkService.GetAllBanks();

        // GET api/<BankController>/5
        [HttpGet("{bankId}")]
        public ActionResult<Bank> Get(string bankId)
        {
            var bank = clerkService.GetBank(bankId);
            if (bank == null)
                return NotFound("Not Found a bank with id!");
            return Ok(bank);
        }

        // POST api/<BankController>
        [HttpPost]
        public IActionResult Post(Bank bank)
        {
            clerkService.AddBank(bank);
            return CreatedAtAction(nameof(Post), new { bankId = bank.BankId }, bank);
        }

        // PUT api/<BankController>/5
        [HttpPut("{bankId}")]
        public IActionResult Put(string bankId,Bank bank)
        {
            var result = clerkService.Check(bankId);
            if (result != null)
                return NotFound(result);
            else if (bankId != bank.BankId)
                return BadRequest("Bad request! recheck your bank-id");
            clerkService.UpdateBank(bankId,bank);
            return Ok("Success");
        }
        // DELETE api/<BankController>/5
        [HttpDelete("{bankId}")]
        public IActionResult Delete(string bankId)
        {
            var result = clerkService.Check(bankId);
            if (result != null)
                return NotFound(result);
            clerkService.DeleteBank(bankId);
            return Ok("success!");
        }
    

        
    }
}
