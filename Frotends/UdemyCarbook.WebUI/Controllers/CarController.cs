using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class CarController : BaseController
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
            SetPage("Araçlarımız", "Aracınızı Seçiniz");
            var values = await _carPricingApiService.GetCarPricingWithTimePeriodAsync<ResultCarPirincingDto>();
            return View(values);
        }

        public IActionResult CarDetail(int id)
        {
            SetPage("Araç Detayları", "Aracın Teknik Aksesuar ve Özellikleri");
            ViewBag.carId = id;
            return View();
        }
    }
}
