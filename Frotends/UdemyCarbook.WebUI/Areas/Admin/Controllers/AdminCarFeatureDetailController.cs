using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarFeatures;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly ICarFeatureApiService _carFeatureApiService;
        public AdminCarFeatureDetailController(ICarFeatureApiService carFeatureApiService)
        {
            _carFeatureApiService = carFeatureApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var values = await _carFeatureApiService.GetByCarIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdResultDto> getCarFeatureByCarIdResultDto)
        {
            await _carFeatureApiService.UpdateAvailabilityBatchAsync(getCarFeatureByCarIdResultDto);
            return RedirectToAction("Index", "AdminCar");
        }

        [HttpGet]
        public async Task<IActionResult> CreateCarFeatureByCar()
        {
            var values = await _carFeatureApiService.GetAllFeaturesAsync();
            return View(values);
        }
    }
}
