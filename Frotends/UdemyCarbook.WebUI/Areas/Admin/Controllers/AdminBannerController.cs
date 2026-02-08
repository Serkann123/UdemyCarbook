using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.BannerDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminBannerController : Controller
    {
        private readonly IBannerApiService _bannerApiService;

        public AdminBannerController(IBannerApiService bannerApiService)
        {
            _bannerApiService = bannerApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bannerApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateBanner()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBanner(CreateBannerDto createBannerDto)
        {
            var ok = await _bannerApiService.CreateAsync(createBannerDto);
            if (ok)
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });

            return View(createBannerDto);
        }

        public async Task<IActionResult> RemoveBanner(int id)
        {
            var ok = await _bannerApiService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBanner(int id)
        {
            var value = await _bannerApiService.GetByIdAsync(id);
            if (value is null) return RedirectToAction("Index");

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBanner(UpdateBannerDto updateBannerDto)
        {
            var ok = await _bannerApiService.UpdateAsync(updateBannerDto);
            if (ok)
                return RedirectToAction("Index", "AdminBanner", new { area = "Admin" });

            return View(updateBannerDto);
        }
    }
}
