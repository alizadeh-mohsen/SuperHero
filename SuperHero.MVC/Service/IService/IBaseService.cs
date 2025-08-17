using SuperHero.MVC.Models;

namespace SuperHero.MVC.Services
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto requestDto);
    }
}
