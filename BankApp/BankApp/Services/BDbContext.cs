using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Services
{
    public class BDbContext:DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(b => b.BankId);
            });
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(a => new
                {
                    a.BankId,
                    a.AccountId
                });
                
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => new
                {
                    t.BankId,
                    t.AccountId,
                    t.TransactionId
                });
                
            });
            modelBuilder.Entity<Clerk>(entity =>
            {
                entity.HasKey(c => new
                {
                    c.BankId,
                    c.ClerkId
                });
            });

        }
    }
}
