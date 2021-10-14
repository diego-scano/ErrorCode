using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder
                .HasKey(l => l.Id);

            builder
                .Property(l => l.LoanDate)
                .IsRequired();

            builder
                .Property(l => l.ReturnDate)
                .IsRequired(false);

            builder
                .HasOne(l => l.Book)
                .WithMany(b => b.Loans)
                .HasForeignKey(l => l.BookId);
        }
    }
}
