using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3D1_BookAPI.Models;

namespace W3D1_BookAPI.Data
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=book.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "Michael", LastName = "Crichton", BirthDate = new DateTime(1942 / 10 / 23) },
                new Author { Id = 2, FirstName = "J.K.", LastName = "Rowling", BirthDate = new DateTime(1965 / 07 / 31) }
                );
            builder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "Jurassic Park", AuthorId = 1, Category = "Fiction" },
                new Book { Id = 2, Title = "The Lost World", AuthorId = 1, Category = "Fiction" },
                new Book { Id = 3, Title = "Harry Potter", AuthorId = 2, Category = "Fantasy" }            
                );
        }
    }
}
