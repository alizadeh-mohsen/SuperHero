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
                    Image = "Supermanflying.png"
                },
                new Hero
                {
                    Id = "2",
                    Name = "WonderWoman",
                    Level = Level.Planet,
                    Universe = Universe.DC,
                    Image = "Wonder_Woman_(2017_film)_poster.jpg"
                }, new Hero
                {
                    Id = "3",
                    Name = "Batman",
                    Level = Level.Street,
                    Universe = Universe.DC,
                    Image = "Batman_Arkham_City_Game_Cover.jpg"
                }, new Hero
                {
                    Id = "4",
                    Name = "SpiderMan",
                    Level = Level.Superhuman,
                    Universe = Universe.Marvel,
                    Image = "Web_of_Spider-Man_Vol_1_129-1.png"
                }, new Hero
                {
                    Id = "5",
                    Name = "The Hulk",
                    Level = Level.City,
                    Universe = Universe.Marvel,
                    Image = "Hulk_(circa_2019).png"
                }, new Hero
                {
                    Id = "6",
                    Name = "Thor",
                    Level = Level.Cosmic,
                    Universe = Universe.Marvel,
                    Image = "Thor_(film)_poster.jpg"
                }, new Hero
                {
                    Id = "7",
                    Name = "Galactus",
                    Level = Level.Cosmic,
                    Universe = Universe.DC,
                    Image = "Galactus_(2018).jpg"
                }, new Hero
                {
                    Id = "8",
                    Name = "IronMan",
                    Level = Level.Superhuman,
                    Universe = Universe.Marvel,
                    Image= "Iron_Man_(circa_2018).png"
                }
            );
        }
    }
}