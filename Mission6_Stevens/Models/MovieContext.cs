﻿using Microsoft.EntityFrameworkCore;
namespace Mission6_Stevens.Models
{
    public class MovieContext : DbContext // Liaison between the database and the application
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) // Constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Seeding the database
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Miscellaneous"},
                new Category { CategoryId = 2, CategoryName = "Drama" },
                new Category { CategoryId = 3, CategoryName = "Television" },
                new Category { CategoryId = 4, CategoryName = "Horro/Suspense" },
                new Category { CategoryId = 5, CategoryName = "Comedy" },
                new Category { CategoryId = 6, CategoryName = "Family" },
                new Category { CategoryId = 7, CategoryName = "Action/Adventure" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
                );
        }
    }
}