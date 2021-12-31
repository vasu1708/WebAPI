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
            var account = clerkService.GetAccount(bankId, accountId);
            if(account == null)
                return NotFound("Not Found! recheck your bank-id or account-id");
            return Ok(account);
        }

        // POST api/<AccountController>
        [HttpPost("{bankId}")]
        public IActionResult Post(string bankId,Account account)
        {
            if (clerkService.GetBank(bankId) is null)
                return NotFound("Bank with that ID is not found!");
            clerkService.AddAccount(bankId,account);
            return CreatedAtAction(nameof(Post), new { accountId = account.AccountId },account);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{bankId}/{accountId}")]
        public IActionResult Put(string bankId,string accountId, Account account)
        {
            if (clerkService.GetAccount(bankId, accountId) == null || accountId != account.AccountId)
                return NotFound("Not Found! Recheck your bank-id and account-id");
            clerkService.UpdateAccount(bankId,account);
            return Ok("success!");
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{bankId}/{accountId}")]
        public IActionResult Delete(string bankId,string accountId)
        {
            if (clerkService.GetAccount(bankId, accountId) == null)
                return NotFound("Not Found! Recheck your bank-id and account-id");
            clerkService.DeleteAccount(bankId,accountId);
            return Ok("Success!");
        }
    }
}
