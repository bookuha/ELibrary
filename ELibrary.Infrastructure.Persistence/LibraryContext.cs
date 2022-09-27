using ELibrary.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.Infrastructure.Persistence
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<DownloadableFile> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ELibrary;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Authors)
                .WithMany(a => a.Books)
                .UsingEntity(j => j.ToTable("BooksAuthors"));

            modelBuilder.Entity<Book>()
                .HasMany(b => b.DownloadableFiles)
                .WithOne(df => df.Book);
        }
    }
}