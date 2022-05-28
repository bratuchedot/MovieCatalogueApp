using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieCatalogueApp.Models;

namespace MovieCatalogueApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MovieCatalogueApp.Models.Movie>? Movie { get; set; }
        public DbSet<MovieCatalogueApp.Models.Person>? Person { get; set; }
        public DbSet<MovieCatalogueApp.Models.Genre>? Genre { get; set; }
        public DbSet<MovieCatalogueApp.Models.Role>? Role { get; set; }
    }
}