using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.SocialMediaDtos;
using UdemyCarbook.WebUI.Extensions;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminSocialMediaController : Controller
    {
        private readonly ISocialMediaApiService _socialMediaApiService;

        public AdminSocialMediaController(ISocialMediaApiService socialMediaApiService)
        {
            _socialMediaApiService = socialMediaApiService;
        }

        public async Task<IActionResult> Index([FromQuery] BaseFilterRequest req)
        {
            var values = await _socialMediaApiService.GetAllAsync();

            var pagedList = values.ToFilteredPagedList(this, req,
              (x, search) => (x.Name ?? "").Contains(search, StringComparison.OrdinalIgnoreCase));

            return View(pagedList);
        }

        [HttpGet]
        public IActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto dto)
        {
            var ok = await _socialMediaApiService.CreateAsync(dto);
            if (ok)
                return RedirectToAction(nameof(Index), "AdminSocialMedia", new { area = "Admin" });

            return View(dto);
        }

        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _socialMediaApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var value = await _socialMediaApiService.GetByIdAsync(id);
            if (value is null) return View();

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto dto)
        {
            var ok = await _socialMediaApiService.UpdateAsync(dto);
            if (ok)
                return RedirectToAction(nameof(Index), "AdminSocialMedia", new { area = "Admin" });

            return View(dto);
        }
    }
}
