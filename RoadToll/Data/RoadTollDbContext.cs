using Microsoft.EntityFrameworkCore;
using RoadToll.Models;

namespace RoadToll.Data
{
    public class RoadTollDbContext : DbContext
    {
        public RoadTollDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add your custom configurations here
        }
    }
}
