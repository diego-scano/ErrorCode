using Core.Models;
using Microsoft.EntityFrameworkCore;
using EF.Configurations;

namespace EF
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base() { }   // WCF

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }   // ASP.NET Core

        public DbSet<Book> Books { get; set; }

        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new LoanConfiguration());
        }
    }
}
