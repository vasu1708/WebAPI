namespace BankApp.Models
{
    public class Bank
    {
        public string BankId { get; set; }
        public string BankName { get; set; }
        public decimal BankBalance { get; set; }
        public decimal SameBankIMPS { get; set; }
        public decimal SameBankRTGS { get; set; }
        public decimal OtherBankIMPS { get; set; }
        public decimal OtherBankRTGS { get; set; }
        public DateTime EstablishedDate { get; set; }
        public bool IsActive { get; set; }
        public List<Account> Accounts { get; set; }
        public List<Clerk> Clerks { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
