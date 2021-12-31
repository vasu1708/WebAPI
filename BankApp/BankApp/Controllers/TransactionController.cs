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
           var transaction = clerkService.GetTransaction(bankId, accountId, transactionId);
            if (transaction == null)
                return NotFound("Not found a transaction with that bank-id ,account-id");
            return Ok(transaction);
        }

        // POST api/<TransactionController>
        [HttpPost("{bankId}/{accountId}")]
        public IActionResult Post(string bankId,string accountId,Transaction transaction)
        {
            if (clerkService.GetBank(bankId) == null)
                return NotFound("Bank not found with that id");
            if (clerkService.GetAccount(bankId, accountId) == null)
                return NotFound("Account not found with that id"); 
            clerkService.AddTransaction(bankId,accountId, transaction);
            return CreatedAtAction(nameof(Post), new { id = transaction.TransactionId }, transaction);
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{bankId}/{accountId}/{transactionId}")]
        public IActionResult Put(string bankId,string accountId,string transactionId,Transaction transaction)
        {
            if (clerkService.GetTransaction(bankId, accountId,transactionId) == null || transactionId != transaction.TransactionId)
                return NotFound("Not Found! Recheck your bank-id or account-id or transacton-id");
            clerkService.UpdateTransaction(transactionId,transaction);
            return Ok("Success!");
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{bankId}/{accountId}/{transactionId}")]
        public IActionResult Delete(string bankId,string accountId,string transactionId)
        {

            if (clerkService.GetTransaction(bankId, accountId, transactionId) == null)
                return NotFound("Not Found! Recheck your bank-id or account-id or transacton-id");
            clerkService.DeleteTransaction(bankId,accountId,transactionId);
            return Ok("Success!");
        }
    }
}
