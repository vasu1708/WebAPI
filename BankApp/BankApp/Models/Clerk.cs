﻿namespace BankApp.Models
{
    public class Clerk
    {
        public string BankId { get; set; }
        public string ClerkId { get; set; }
        public string ClerkName { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public bool IsActive { get; set; }
        public Bank Bank { get; set; }
    }
}
