namespace SuperHero.API.Data.Dto
{
    public class HeroDto
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public string Level { get; set; }
        public string Universe { get; set; } 
        public string? Image { get; set; }
    }
}
