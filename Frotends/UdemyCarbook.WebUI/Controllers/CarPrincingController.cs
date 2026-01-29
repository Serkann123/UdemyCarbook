using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class CarPrincingController : Controller
    {
        private readonly ICarPricingApiService _carPricingApiService;
        public CarPrincingController(ICarPricingApiService carPricingApiService)
        {
            _carPricingApiService = carPricingApiService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";

            var values = await _carPricingApiService.GetCarPricingWithTimePeriodAsync<ResultCarPrincingListModelDto>();
            return View(values);
        }
    }
}
