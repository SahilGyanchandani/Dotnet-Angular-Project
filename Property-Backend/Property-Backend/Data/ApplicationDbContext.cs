using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Property_Backend.Model;

namespace Property_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
           base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedCities(builder);
        }

        private void SeedCities(ModelBuilder builder)
        {
            builder.Entity<City>().HasData(
                new City() { cityId = 1, cityName = "Surat" },
                new City() { cityId = 2, cityName = "Ahmedabad" },
                new City() { cityId = 3, cityName = "Vadodara" },
                new City() { cityId = 4, cityName = "Pune" }
                );
        }

        public DbSet<City> Cities { get; set; }
    }
}
