using Microsoft.EntityFrameworkCore;

namespace movies.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public ApplicationContext() {
        
        
        }
        //when doing injection
        public ApplicationContext( DbContextOptions options) : base(options) { 
        
        }
       



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=DESKTOP-DGIE8P7\\SQLEXPRESS;Database=movies;Trusted_Connection=True;TrustServerCertificate=True"));
        }
    }
}
