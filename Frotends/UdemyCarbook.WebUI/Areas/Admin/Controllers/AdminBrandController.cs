using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.BrandDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminBrandController : Controller
    {
        private readonly IBrandApiService _brandService;

        public AdminBrandController(IBrandApiService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _brandService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var ok = await _brandService.CreateAsync(createBrandDto);
            if (ok) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> RemoveBrand(int id)
        {
            var ok = await _brandService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            var value = await _brandService.GetByIdAsync(id);
            if (value == null) return RedirectToAction("Index");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var ok = await _brandService.UpdateAsync(updateBrandDto);
            if (ok) return RedirectToAction("Index");
            return View();
        }
    }
}
