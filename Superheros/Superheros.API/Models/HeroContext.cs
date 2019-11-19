using Microsoft.EntityFrameworkCore;

namespace Superheros.API.Models
{
    public class HeroContext : DbContext
    {
        public DbSet<Hero> Heros { get; set; }

        public HeroContext(DbContextOptions<HeroContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hero>()
                .ToTable("Heros", "Core");
        }
    }
}
