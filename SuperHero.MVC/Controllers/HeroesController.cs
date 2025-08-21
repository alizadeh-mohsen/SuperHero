using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using SuperHero.MVC.Models;
using SuperHero.MVC.Service.IService;

namespace SuperHero.MVC.Controllers
{
    public class HeroesController(IHeroService _heroService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            Log.Warning(">>>>>>>>>> MVC: Stared fetching all heroes from the API");
            var model = new List<HeroDto>();
            var responseDto = await _heroService.GetHeroesAsync();
            if (responseDto.IsSuccess)
                model = JsonConvert.DeserializeObject<List<HeroDto>>(Convert.ToString(responseDto.Result));
            else
                TempData["error"] = responseDto.Message;

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new HeroDto();

            var responseDto = await _heroService.GetHeroAsync(id);
            if (responseDto.IsSuccess)
                model = JsonConvert.DeserializeObject<HeroDto>(Convert.ToString(responseDto.Result));
            else
                TempData["error"] = responseDto.Message;
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HeroDto HeroDto)
        {
            if (ModelState.IsValid)
            {
                var responseDto = await _heroService.CreateHeroAsync(HeroDto);
                if (responseDto.IsSuccess)
                {
                    TempData["success"] = "Hero created successfully.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["error"] = responseDto.Message;
                }
            }
            return View(HeroDto);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await GetHeroById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HeroDto HeroDto)
        {
            var model = new HeroDto();
            var responseDto = await _heroService.UpdateHeroAsync(HeroDto);
            if (responseDto.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
            {
                TempData["error"] = responseDto.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var model = await GetHeroById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var responseDto = await _heroService.DeleteHeroAsync(id);
            if (responseDto.IsSuccess)
                return RedirectToAction(nameof(Index));
            else
            {
                TempData["error"] = responseDto.Message;
                return View();
            }
        }


        private async Task<HeroDto> GetHeroById(int id)
        {
            var response = await _heroService.GetHeroAsync(id);
            if (!response.IsSuccess)
            {
                TempData["error"] = response.Message;
                return null; // Return an empty CouponDto if not found
            }
            return JsonConvert.DeserializeObject<HeroDto>(Convert.ToString(response.Result));
        }

    }
}
