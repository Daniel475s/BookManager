using BookManager.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.API.Persistence
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>(e =>
            {
                e.HasKey(b => b.Id);

                e.Property(b => b.Title).HasColumnType("varchar(200)");
                e.Property(b => b.Autor).IsRequired(false);
                e.Property(b => b.ISBN).IsRequired(false);
                e.Property(b => b.YearOfPublication)
                .HasColumnName("Year_Of_Publication");
            });
        }
    }
}
