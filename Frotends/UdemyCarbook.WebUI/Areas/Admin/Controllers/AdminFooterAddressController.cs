using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.FooterAdressDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminFooterAddressController : Controller
    {
        private readonly IFooterAddressApiService _footerAddressApiService;

        public AdminFooterAddressController(IFooterAddressApiService footerAddressApiService)
        {
            _footerAddressApiService = footerAddressApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _footerAddressApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFooterAddress()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressDto createFooterAddressDto)
        {
            var ok = await _footerAddressApiService.CreateAsync(createFooterAddressDto);
            if (ok)
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });

            return View(createFooterAddressDto);
        }

        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            var ok = await _footerAddressApiService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFooterAddress(int id)
        {
            var value = await _footerAddressApiService.GetByIdAsync(id);
            if (value is null) return RedirectToAction("Index");

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressDto updateFooterAddressDto)
        {
            var ok = await _footerAddressApiService.UpdateAsync(updateFooterAddressDto);
            if (ok)
                return RedirectToAction("Index", "AdminFooterAddress", new { area = "Admin" });

            return View(updateFooterAddressDto);
        }
    }
}
