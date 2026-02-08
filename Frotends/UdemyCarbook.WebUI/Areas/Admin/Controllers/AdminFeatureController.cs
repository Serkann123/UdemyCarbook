using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.FeatureDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminFeatureController : Controller
    {
        private readonly IFeatureApiService _featureApiService;

        public AdminFeatureController(IFeatureApiService featureApiService)
        {
            _featureApiService = featureApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _featureApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var ok = await _featureApiService.CreateAsync(createFeatureDto);
            if (ok) return RedirectToAction("Index");

            return View(createFeatureDto);
        }

        public async Task<IActionResult> RemoveFeature(int id)
        {
            var ok = await _featureApiService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeature(int id)
        {
            var value = await _featureApiService.GetByIdAsync(id);
            if (value is null) return RedirectToAction("Index");

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var ok = await _featureApiService.UpdateAsync(updateFeatureDto);
            if (ok) return RedirectToAction("Index");

            return View(updateFeatureDto);
        }
    }
}
