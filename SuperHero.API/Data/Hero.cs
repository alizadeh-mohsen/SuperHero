using SuperHero.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace SuperHero.API.Data
{
    public class Hero
    {
        public string Id { get; set; } = new Guid().ToString();
        public required string Name { get; set; }
        public Level Level { get; set; }
        public Universe Universe { get; set; } = Universe.Marvel;
        public string? Image { get; set; }
    }

    public enum Universe
    {
        Marvel,
        DC
    }
    public enum Level
    {
        Street,
        Superhuman,
        City,
        Planet,
        Cosmic
    }

}