using BankApp.Models;

namespace BankApp.Services
{
    public  class ClerkService
    {
        public BDbContext context { get; set; }
        public ClerkService() => context = new DbContextService(new SqlServerDbContext()).GetDbContext();

        public string Check(string bankId)
        {
           if(GetBank(bankId) == null)
                return "Not Found a bank with that id!";
            return null;
        }
        public string Check(string bankId,string accountId)
        {
            var result = Check(bankId);
            if ( result == null && GetAccount(bankId, accountId) == null)
                result = "Not Found a account with that id!";
            return result;
        }
        public string CheckClerk(string bankId,string clerkId)
        {
            var result = Check(bankId);
            if (result == null && GetClerk(bankId, clerkId) == null)
                result = "Not Found a clerk with that id!";
            return result;
        }
        public string Check(string bankId,string accountId,string transactionId)
        {
            var result = Check(bankId, accountId);
            if (result == null && GetTransaction(bankId, accountId,transactionId) == null)
                result = "Not Found a transaction with id!";
            return result;
        }


        internal List<Bank> GetAllBanks() =>  context.Banks.Where(b => b.IsActive == true).ToList();
        internal  Bank GetBank(string bankId) => context.Banks.SingleOrDefault(b => b.BankId == bankId && b.IsActive == true);
        internal void AddBank(Bank bank)
        {
            context.Banks.Add(bank); 
            context.SaveChanges();
        }
        internal  void UpdateBank(string bankId,Bank bank)
        {
            context.Banks.Remove(GetBank(bankId));
            context.Banks.Add(bank);
            context.SaveChanges();
        }
        internal  void DeleteBank(string bankId)
        {
            GetBank(bankId).IsActive = false;
            context.SaveChanges();
            foreach (var account in GetAllAccounts(bankId))
                DeleteAccount(bankId, account.AccountId);
            foreach(var clerk in GetAllClerks(bankId))
                DeleteClerk(bankId,clerk.ClerkId);
        }
        



        internal  List<Account> GetAllAccounts(string bankId) => context.Accounts.Where(a => a.BankId == bankId && a.IsActive == true).ToList();
        internal  Account GetAccount(string bankId, string accountId) => GetAllAccounts(bankId).SingleOrDefault(a => a.AccountId == accountId && a.IsActive == true);
        internal  void AddAccount(string bankId,Account account)
        {
            context.Accounts.Add(account);
            context.SaveChanges();
        }
        internal  void UpdateAccount(string bankId,string accountId,Account account)
        {
            context.Accounts.Remove(GetAccount(bankId,accountId));
            context.Accounts.Add(account);
            context.SaveChanges();
        }
        internal  void DeleteAccount(string bankId, string accountId)
        {
            GetAccount(bankId, accountId).IsActive = false;
            context.SaveChanges();
            foreach(var txn in GetAllTransactions(bankId, accountId))
                DeleteTransaction(bankId,accountId,txn.TransactionId);
        }
       
        




        internal  List<Clerk> GetAllClerks(string bankId) => context.Clerks.Where(c => c.BankId == bankId && c.IsActive == true).ToList();
        internal  Clerk GetClerk(string bankId,string clerkId) => GetAllClerks(bankId).SingleOrDefault(c => c.ClerkId == clerkId && c.IsActive == true);
        internal  void AddClerk(string bankId,Clerk clerk)
        {
            context.Clerks.Add(clerk);
            context.SaveChanges();
        }
        internal  void UpdateClerk(string bankId,string clerkId,Clerk clerk)
        {
            context.Clerks.Remove(GetClerk(bankId,clerkId));
            context.Clerks.Add(clerk);
            context.SaveChanges();
        }
        internal  void DeleteClerk(string bankId, string clerkId)
        {
            GetClerk(bankId, clerkId).IsActive = false;
            context.SaveChanges();
        }
        




        internal  List<Transaction> GetAllTransactions(string bankId, string accountId) => context.Transactions.Where(t => t.BankId == bankId && t.AccountId == accountId && t.IsActive == true).ToList();
        internal  Transaction GetTransaction(string bankId, string accountId, string transactionId) => context.Transactions.SingleOrDefault(t => t.TransactionId == transactionId && t.IsActive == true);
        internal  void AddTransaction(string bankId, string accountId, Transaction transaction)
        {
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }
        internal  void UpdateTransaction(string bankId,string accountId,string transactionId, Transaction transaction)
        {
            context.Transactions.Remove(GetTransaction(bankId,accountId, transactionId));
            context.Transactions.Add(transaction);
            context.SaveChanges();
        }
        internal  void DeleteTransaction(string bankId,string accountId,string transactionId)
        {
            GetTransaction(bankId, accountId, transactionId).IsActive = false;
            context.SaveChanges();
        }
        







    }
}
