
using BankApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Services
{
    public class DbContextService
    {
        private readonly BDbContext _context;
        public DbContextService(BDbContext context)
        {
            _context = context;
        }
        public BDbContext GetDbContext()
        {
            return _context;
        }
    }
}
