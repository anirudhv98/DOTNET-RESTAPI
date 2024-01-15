using AniRecipes.Models;
using Microsoft.EntityFrameworkCore;


namespace AniRecipes.Data
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
              : base(options)
        {

        }
        public DbSet<Recipe> Recipes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasData(
                new Recipe()
                {
                    Id = 1,
                    Name = "Dosa",
                    CreatedDate = DateTime.Now

                },
                new Recipe()
                {
                    Id = 2,
                    Name = "Idli",
                    CreatedDate = DateTime.Now

                },
                new Recipe()
                {
                    Id = 3,
                    Name = "Medu-Vada",
                    CreatedDate = DateTime.Now

                },
                new Recipe()
                {
                    Id = 4,
                    Name = "Pongal",
                    CreatedDate = DateTime.Now

                },
                new Recipe()
                { Id=5,
                    Name= "Appam",
                    CreatedDate = DateTime.Now
                }
                );
        }
    }
}
