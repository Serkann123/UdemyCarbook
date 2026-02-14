using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.PirincingDtos;
using UdemyCarbook.WebUI.Extensions;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminPricingController : Controller
    {
        private readonly IPricingApiService _pricingApiService;

        public AdminPricingController(IPricingApiService pricingApiService)
        {
            _pricingApiService = pricingApiService;
        }

        public async Task<IActionResult> Index([FromQuery] BaseFilterRequest req)
        {
            var values = await _pricingApiService.GetAllAsync();

            var pagedList = values.ToFilteredPagedList(this, req,
                (x, search) => (x.Name ?? "").Contains(search, StringComparison.OrdinalIgnoreCase));

            return View(pagedList);
        }

        [HttpGet]
        public IActionResult CreatePricing()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePrincingDto dto)
        {
            var ok = await _pricingApiService.CreateAsync(dto);
            if (ok) return RedirectToAction(nameof(Index), "AdminPrincing", new { area = "Admin" });
            return View(dto);
        }

        public async Task<IActionResult> RemovePricing(int id)
        {
            var ok = await _pricingApiService.RemoveAsync(id);
            if (ok) return RedirectToAction(nameof(Index));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePricing(int id)
        {
            var value = await _pricingApiService.GetByIdAsync(id);
            if (value is null) return RedirectToAction(nameof(Index));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePricing(UpdatePrincingDto dto)
        {
            var ok = await _pricingApiService.UpdateAsync(dto);
            if (ok) return RedirectToAction(nameof(Index), "AdminPrincing", new { area = "Admin" });
            return View(dto);
        }
    }
}
