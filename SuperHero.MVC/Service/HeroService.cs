using Serilog;
using SuperHero.MVC.Models;
using SuperHero.MVC.Service.IService;

namespace SuperHero.MVC.Services
{
    public class HeroService(IBaseService _baseService) : IHeroService
    {
        //private readonly string _baseApiUrl = "http://localhost:7161/api/hero";
        //private readonly string _baseApiUrl = "http://superhero.api:7161/api/hero";
        //private readonly string _baseApiUrl = "https://api.hero.com:44310/api/hero";
        private readonly string url = "api/hero";
        public async Task<ResponseDto> GetHeroesAsync()
        {
            Log.Warning(">>>>>>>>>> MVC: inside Service");

            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypeEnum.GET,
                Url = $"{url}"
            });
        }

        public async Task<ResponseDto> GetHeroAsync(int id)
        {
            Log.Warning(">>>>>>>>>> MVC: inside Service");
            
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypeEnum.GET,
                Url = $"{url}/{id}"
            });
        }

        public async Task<ResponseDto> CreateHeroAsync(HeroDto HeroDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypeEnum.POST,
                Url = $"{url}",
                Data = HeroDto
            });
        }

        public async Task<ResponseDto> DeleteHeroAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypeEnum.DELETE,
                Url = $"{url}/{id}"
            });
        }
        public async Task<ResponseDto> UpdateHeroAsync(HeroDto HeroDto)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = ApiTypeEnum.PUT,
                Url = $"{url}/{HeroDto.Id}",
                Data = HeroDto
            });
        }
    }
}
