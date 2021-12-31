namespace BankApp.Models
{
    public class Transaction
    {
        public string BankId { get; set; }
        public string AccountId { get; set; }
        public string TransactionId { get; set; }
        public string SenderAccountId { get; set; }
        public string ReceiverAccountId { get; set; }
        public Enums.TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeOfTransaction { get; set; }
        public Enums.CurrencyType Currency { get; set; }
        public bool IsActive { get; set; }
    }
}
