using Microsoft.AspNetCore.Mvc;
using BankApp.Models;
using BankApp.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ClerkService clerkService;
        public TransactionController()
        {
            clerkService = new ClerkService();
        }
        // GET: api/<TransactionController>
        [HttpGet]
        public ActionResult<List<Transaction>> GetAll(string bankId, string accountId) => clerkService.GetAllTransactions(bankId, accountId);

        // GET api/<TransactionController>/5
        [HttpGet("{bankId}/{accountId}/{transactionId}")]
        public ActionResult<Transaction> Get(string bankId, string accountId, string transactionId)
        {
            var result = clerkService.Check(bankId, accountId, transactionId);
            if (result != null)
                return NotFound(result);
            return Ok(clerkService.GetTransaction(bankId,accountId,transactionId));
        }

        // POST api/<TransactionController>
        [HttpPost("{bankId}/{accountId}")]
        public IActionResult Post(string bankId,string accountId,Transaction transaction)
        {
            var result = clerkService.Check(bankId, accountId);
            if (result != null)
                return NotFound(result);
            else if (bankId != transaction.BankId || accountId != transaction.AccountId )
                return BadRequest("Bad request! recheck your bank-id, account-id");
            clerkService.AddTransaction(bankId,accountId, transaction);
            return CreatedAtAction(nameof(Post), new { id = transaction.TransactionId }, transaction);
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{bankId}/{accountId}/{transactionId}")]
        public IActionResult Put(string bankId,string accountId,string transactionId,Transaction transaction)
        {
            var result = clerkService.Check(bankId, accountId, transactionId);
            if (result != null)
                return NotFound(result);
            else if (bankId != transaction.BankId || accountId != transaction.AccountId || transactionId != transaction.TransactionId)
                return BadRequest("Bad request! recheck your bank-id, account-id & transaction-id");
            clerkService.UpdateTransaction(bankId,accountId,transactionId,transaction);
            return Ok("Success!");
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{bankId}/{accountId}/{transactionId}")]
        public IActionResult Delete(string bankId,string accountId,string transactionId)
        {
            var result = clerkService.Check(bankId, accountId, transactionId);
            if (result != null)
                return NotFound(result);
            clerkService.DeleteTransaction(bankId,accountId,transactionId);
            return Ok("Success!");
        }
    }
}
