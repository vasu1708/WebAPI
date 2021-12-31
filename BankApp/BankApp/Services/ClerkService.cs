using BankApp.Models;

namespace BankApp.Services
{
    public  class ClerkService
    {
        
         List<Bank> Banks = new List<Bank>();
         List<Clerk> Clerks = new List<Clerk>();
         List<Account> Accounts = new List<Account>();
         List<Transaction> Transactions = new List<Transaction>();

        internal  List<Bank> GetAllBanks() => Banks.Where(b => b.IsActive == true).ToList();
        internal  Bank GetBank(string bankId) => Banks.SingleOrDefault(b => b.BankId == bankId && b.IsActive == true);
        internal  void AddBank(Bank bank) => Banks.Add(bank);
        internal  void UpdateBank(string bankId,Bank bank)
        {
            int indx = Banks.FindIndex(b => b.BankId == bankId);
            Banks.Insert(indx, bank);
        }
        internal  void DeleteBank(string bankId)
        {
            GetBank(bankId).IsActive = false;
            foreach (var account in GetAllAccounts(bankId))
                DeleteAccount(bankId, account.AccountId);
            foreach(var clerk in GetAllClerks(bankId))
                DeleteClerk(bankId,clerk.ClerkId);
        }
        



        internal  List<Account> GetAllAccounts(string bankId) => Accounts.Where(a => a.BankId == bankId && a.IsActive == true).ToList();
        internal  Account GetAccount(string bankId, string accountId) => GetAllAccounts(bankId).SingleOrDefault(a => a.AccountId == accountId && a.IsActive == true);
        internal  void AddAccount(string bankId,Account account) => Accounts.Add(account);
        internal  void UpdateAccount(string accountId,Account account)
        {
            int indx = Accounts.FindIndex(a => a.AccountId == accountId);
            Accounts.Insert(indx, account);
        }
        internal  void DeleteAccount(string bankId, string accountId)
        {
            GetAccount(bankId, accountId).IsActive = false;
            foreach(var txn in GetAllTransactions(bankId, accountId))
                DeleteTransaction(bankId,accountId,txn.TransactionId);
        }
       
        




        internal  List<Clerk> GetAllClerks(string bankId) => Clerks.Where(c => c.BankId == bankId && c.IsActive == true).ToList();
        internal  Clerk GetClerk(string bankId,string clerkId) => GetAllClerks(bankId).SingleOrDefault(c => c.ClerkId == clerkId && c.IsActive == true);
        internal  void AddClerk(string bankId,Clerk clerk) => Clerks.Add(clerk);
        internal  void UpdateClerk(string clerkId,Clerk clerk)
        {
            int indx = Clerks.FindIndex(c => c.ClerkId == clerkId);
            Clerks.Insert(indx, clerk);
        }
        internal  void DeleteClerk(string bankId, string clerkId) => GetClerk(bankId, clerkId).IsActive = false;
        




        internal  List<Transaction> GetAllTransactions(string bankId, string accountId) => Transactions.Where(t => t.BankId == bankId && t.AccountId == accountId && t.IsActive == true).ToList();
        internal  Transaction GetTransaction(string bankId, string accountId, string transactionId) => GetAllTransactions(bankId, accountId).SingleOrDefault(t => t.TransactionId == transactionId && t.IsActive == true);
        internal  void AddTransaction(string bankId, string accountId, Transaction transaction)
        {
            GetAllTransactions(bankId, accountId).Add(transaction);
        }
        internal  void UpdateTransaction(string transactionId, Transaction transaction)
        {
            int indx = Transactions.FindIndex(t => t.TransactionId == transactionId);
            Transactions.Insert(indx, transaction);
        }
        internal  void DeleteTransaction(string bankId,string accountId,string transactionId) => GetTransaction(bankId, accountId, transactionId).IsActive = false;
        







    }
}
