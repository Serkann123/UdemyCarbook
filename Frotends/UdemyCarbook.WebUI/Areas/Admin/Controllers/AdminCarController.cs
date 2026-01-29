using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminCarController : Controller
    {

        private readonly ICarApiService _carApi;
        private readonly IBrandApiService _brandApi;

        public AdminCarController(ICarApiService carApi, IBrandApiService brandApi)
        {
            _carApi = carApi;
            _brandApi = brandApi;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _carApi.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public async Task<ActionResult> CreateCar()
        {
            await LoadBrandsToViewBag();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var ok = await _carApi.CreateAsync(createCarDto);
            if (ok) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var ok = await _carApi.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            await LoadBrandsToViewBag();

            var value = await _carApi.GetByIdAsync(id);
            if (value == null) return RedirectToAction("Index");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var ok = await _carApi.UpdateAsync(updateCarDto);
            if (ok) return RedirectToAction("Index");
            return View();
        }

        private async Task LoadBrandsToViewBag()
        {
            var brands = await _brandApi.GetAllAsync();
            ViewBag.BrandValues = brands.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.BrandId.ToString()
            }).ToList();
        }
    }
}
