using AutoMapper;
using SuperHero.MVC.Models;
using SuperHero.MVC.ViewModels;

namespace SuperHero.MVC.AutoMapper
{
    public class MappingConfigs : Profile
    {
        public MappingConfigs()
        {
            CreateMap<HeroViewModel, HeroDto>().ReverseMap();
        }
    }
}
