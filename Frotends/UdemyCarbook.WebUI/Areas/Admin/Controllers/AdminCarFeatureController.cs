using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarFeatures;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminCarFeatureController : Controller
    {
        private readonly ICarFeatureApiService _carFeatureApiService;
        public AdminCarFeatureController(ICarFeatureApiService carFeatureApiService)
        {
            _carFeatureApiService = carFeatureApiService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var values = await _carFeatureApiService.GetByCarIdAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdResultDto> model)
        {
            await _carFeatureApiService.UpdateCarFeatureAvailableListAsync(model);
            return RedirectToAction("Index", "AdminCar");
        }
    }
}
