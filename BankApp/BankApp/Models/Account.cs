namespace BankApp.Models
{
    public class Account
    {
        public string BankId { get; set; }
        public string AccountId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal AccountBalance { get; set; }
        public string AccountPassword { get; set; }
        public Enums.Gender Gender { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string DateOfBirth { get; set; }
        public Enums.CurrencyType Currency { get; set; }
        public DateTime AccountCreationDate { get; set; }
        public bool IsActive { get; set; }
        /*public Bank Bank { get; set; }
        public List<Transaction> Transactions { get; set; }*/
    }
}
