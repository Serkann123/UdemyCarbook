using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarApiService _carApiService;
        private readonly ICarPricingApiService _carPricingApiService;
        public CarController(ICarApiService carApiService, ICarPricingApiService carPricingApiService)
        {
            _carApiService = carApiService;
            _carPricingApiService = carPricingApiService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";

            var values = await _carPricingApiService.GetCarPricingWithTimePeriodAsync<ResultCarPirincingDto>();
            return View(values);
        }

        public IActionResult CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik Aksesuar Ve Özellikleri";
            ViewBag.carId = id;
            return View();
        }
    }
}
