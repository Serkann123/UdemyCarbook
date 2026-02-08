using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.DefaultCoverComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly IStatisticsApiService _statisticsApiService;

        public _DefaultStatisticComponentPartial(IStatisticsApiService statisticsApiService)
        {
            _statisticsApiService = statisticsApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var dto = await _statisticsApiService.GetDashboardAsync();

            ViewBag.CarCount = dto.CarCount;
            ViewBag.LokasyonCount = dto.LocationCount;
            ViewBag.BrandCount = dto.BrandCount;
            ViewBag.CarCountByFuelElectric = dto.ElectricCarCount;

            return View();
        }
    }
}