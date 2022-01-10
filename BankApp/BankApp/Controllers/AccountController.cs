using BankApp.Models;
using BankApp.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        ClerkService clerkService;
        public AccountController()
        {
            clerkService = new ClerkService();
        }
        // GET: api/<AccountController>
        [HttpGet("{bankId}")]
        public ActionResult<List<Account>> GetAll(string bankId) => clerkService.GetAllAccounts(bankId);

        // GET api/<AccountController>/5
        [HttpGet("{bankId}/{accountId}")]
        public ActionResult<Account> Get(string bankId,string accountId)
        {
            var result = clerkService.Check(bankId, accountId);
            if (result != null)
                return NotFound(result);
            return Ok(clerkService.GetAccount(bankId,accountId));
        }

        // POST api/<AccountController>
        [HttpPost("{bankId}")]
        public IActionResult Post(string bankId,Account account)
        {
            var result = clerkService.Check(bankId);
            if (result != null)
                return NotFound(result);
            else if (bankId != account.BankId)
                return BadRequest("Bad request! recheck your bank-id");
            clerkService.AddAccount(bankId,account);
            return CreatedAtAction(nameof(Post), new { accountId = account.AccountId },account);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{bankId}/{accountId}")]
        public IActionResult Put(string bankId,string accountId, Account account)
        {
            var result = clerkService.Check(bankId, accountId);
            if (result != null)
                return NotFound(result);
            else if (bankId != account.BankId || accountId != account.AccountId || accountId != account.AccountId)
                return BadRequest("Bad request! recheck your bank-id, account-id");
            clerkService.UpdateAccount(bankId,accountId,account);
            return Ok("success!");
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{bankId}/{accountId}")]
        public IActionResult Delete(string bankId,string accountId)
        {
            var result = clerkService.Check(bankId, accountId);
            if (result != null)
                return NotFound(result);
            clerkService.DeleteAccount(bankId,accountId);
            return Ok("Success!");
        }
    }
}
