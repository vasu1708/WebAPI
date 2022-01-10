
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Services
{
    public class DbContextService : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Clerk> Clerks { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-AALRII2;Initial Catalog=BanksDB;Integrated Security=True");
        }
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
                entity.HasOne(a => a.Bank).WithMany(b => b.Accounts).HasForeignKey(a => a.BankId).OnDelete(DeleteBehavior.ClientCascade);
            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => new
                {
                    t.BankId,
                    t.AccountId,
                    t.TransactionId
                });
                entity.HasOne(t => t.Account).WithMany(a => a.Transactions).HasForeignKey(t => new 
                { 
                    t.BankId,
                    t.AccountId
                }).OnDelete(DeleteBehavior.ClientCascade);
            });
            modelBuilder.Entity<Clerk>(entity =>
            {
                entity.HasKey(c => new
                {
                    c.BankId,
                    c.ClerkId
                });
                entity.HasOne(c => c.Bank).WithMany(b => b.Clerks).HasForeignKey(c => c.BankId).OnDelete(DeleteBehavior.ClientCascade);
            });

        }
    }
}
