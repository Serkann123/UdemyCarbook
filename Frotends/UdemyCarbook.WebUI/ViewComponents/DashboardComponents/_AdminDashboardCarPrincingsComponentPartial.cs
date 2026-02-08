using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPrincingsComponentPartial:ViewComponent
    {
        private readonly ICarPricingApiService _carPricingApiService;

        public _AdminDashboardCarPrincingsComponentPartial(
            ICarPricingApiService carPricingApiService)
        {
            _carPricingApiService = carPricingApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _carPricingApiService
                .GetCarPricingWithTimePeriodAsync<ResultCarPrincingListModelDto>();
            return View(values);
        }
    }
}
