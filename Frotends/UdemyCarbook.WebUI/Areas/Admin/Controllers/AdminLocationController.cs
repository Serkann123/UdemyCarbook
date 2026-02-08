using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.LocationDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminLocationController : Controller
    {
        private readonly ILocationApiService _locationApiService;

        public AdminLocationController(ILocationApiService locationApiService)
        {
            _locationApiService = locationApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _locationApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateLocation() => View();

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto dto)
        {
            var ok = await _locationApiService.CreateAsync(dto);
            if (ok) return RedirectToAction(nameof(Index), "AdminLocation", new { area = "Admin" });
            return View(dto);
        }

        public async Task<IActionResult> RemoveLocation(int id)
        {
            var ok = await _locationApiService.RemoveAsync(id);
            if (ok) return RedirectToAction(nameof(Index));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var value = await _locationApiService.GetByIdAsync(id);
            if (value is null) return RedirectToAction(nameof(Index));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto dto)
        {
            var ok = await _locationApiService.UpdateAsync(dto);
            if (ok) return RedirectToAction(nameof(Index), "AdminLocation", new { area = "Admin" });
            return View(dto);
        }
    }
}
