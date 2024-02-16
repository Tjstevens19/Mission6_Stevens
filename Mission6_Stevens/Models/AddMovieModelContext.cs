using Microsoft.EntityFrameworkCore;
namespace Mission6_Stevens.Models
{
    public class AddMovieModelContext : DbContext
    {
        public AddMovieModelContext(DbContextOptions<AddMovieModelContext> options) : base(options)
        {
        }

        public DbSet<AddMovieModel> Movies { get; set; }
    }
}
