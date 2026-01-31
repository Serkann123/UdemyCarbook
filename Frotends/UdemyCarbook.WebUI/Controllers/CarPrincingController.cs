using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class CarPrincingController : BaseController
    {
        private readonly ICarPricingApiService _carPricingApiService;
        public CarPrincingController(ICarPricingApiService carPricingApiService)
        {
            _carPricingApiService = carPricingApiService;
        }

        public async Task<IActionResult> Index()
        {
            SetPage("Paketler", "Araç Fiyat Paketleri");

            var values = await _carPricingApiService.GetCarPricingWithTimePeriodAsync<ResultCarPrincingListModelDto>();
            return View(values);
        }
    }
}
