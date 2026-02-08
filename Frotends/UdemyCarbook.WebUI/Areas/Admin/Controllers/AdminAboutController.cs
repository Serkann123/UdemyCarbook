using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.AboutDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminAboutController : Controller
    {
        private readonly IAboutApiService _aboutApiService;
        public AdminAboutController(IAboutApiService aboutApiService)
        {
            _aboutApiService = aboutApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _aboutApiService.GetAllAsync();
            return View(values);
        }


        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var ok = await _aboutApiService.CreateAsync(createAboutDto);
            if (ok)
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });

            return View();
        }

        public async Task<IActionResult> RemoveAbout(int id)
        {
            var ok = await _aboutApiService.RemoveAsync(id);
            if (ok)
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var value = await _aboutApiService.GetByIdAsync(id);
            if (value is null) return RedirectToAction("Index");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var ok = await _aboutApiService.UpdateAsync(updateAboutDto);
            if (ok)
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });

            return View(updateAboutDto);
        }
    }
}
