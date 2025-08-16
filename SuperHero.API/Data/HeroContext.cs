using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace SuperHero.API.Data
{
    public class HeroContext : DbContext
    {
        public HeroContext(DbContextOptions<HeroContext> options) : base(options)
        {
        }
        public DbSet<Hero> Heroes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Hero
            modelBuilder.Entity<Hero>().HasData(
                new Hero
                {
                    Id = "1",
                    Name = "SuperMan",
                    Level = Level.Planet,
                    Universe = Universe.DC,
                },
                new Hero
                {
                    Id = "2",
                    Name = "WonderWoman",
                    Level = Level.Planet,
                    Universe = Universe.DC,
                }, new Hero
                {
                    Id = "3",
                    Name = "Batman",
                    Level = Level.Street,
                    Universe = Universe.DC,
                }, new Hero
                {
                    Id = "4",
                    Name = "SpiderMan",
                    Level = Level.Superhuman,
                    Universe = Universe.Marvel,
                }, new Hero
                {
                    Id = "5",
                    Name = "The Hulk",
                    Level = Level.City,
                    Universe = Universe.Marvel,
                }, new Hero
                {
                    Id = "6",
                    Name = "Thor",
                    Level = Level.Cosmic,
                    Universe = Universe.Marvel,
                }, new Hero
                {
                    Id = "7",
                    Name = "Galactus",
                    Level = Level.Cosmic,
                    Universe = Universe.DC,
                }, new Hero
                {
                    Id = "8",
                    Name = "IronMan",
                    Level = Level.Superhuman,
                    Universe = Universe.Marvel,
                }
            );
        }
    }
}