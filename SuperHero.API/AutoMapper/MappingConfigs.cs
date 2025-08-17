using AutoMapper;
using SuperHero.API.Data;
using SuperHero.API.Data.Dto;


namespace SuperHero.API.AutoMapper
{
    public class MappingConfigs : Profile
    {
        public MappingConfigs()
        {
            CreateMap<Hero, HeroDto>().ReverseMap();
        }
    }
}
