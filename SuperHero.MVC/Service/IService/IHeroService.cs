using SuperHero.MVC.Models;
using SuperHero.MVC.Services;

namespace SuperHero.MVC.Service.IService
{
    public interface IHeroService
    {
        Task<ResponseDto> GetHeroesAsync();
        Task<ResponseDto> GetHeroAsync(int id);
        Task<ResponseDto> CreateHeroAsync(HeroDto HeroDto);
        Task<ResponseDto> UpdateHeroAsync(HeroDto HeroDto);
        Task<ResponseDto> DeleteHeroAsync(int id);
    }
}
