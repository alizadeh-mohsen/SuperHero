namespace SuperHero.MVC.ViewModels
{
    public class HeroViewModel
    {
        public string Id { get; set; }
        public required string Name { get; set; }
        public string Level { get; set; }
        public string Universe { get; set; }
        public string? Image { get; set; }
    }

    

}