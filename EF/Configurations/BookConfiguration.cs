using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.ISBN)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(b => b.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .Property(b => b.Summary)
                .HasMaxLength(1000)
                .IsRequired();

            builder
                .Property(b => b.Author)
                .HasMaxLength(200);

            builder
                .HasMany(b => b.Loans)
                .WithOne(l => l.Book);
        }
    }
}
