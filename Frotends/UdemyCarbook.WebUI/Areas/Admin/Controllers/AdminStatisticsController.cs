using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.WebUI.Extensions;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminStatisticsController : Controller
    {
        private readonly IStatisticsApiService _statisticsApiService;

        public AdminStatisticsController(IStatisticsApiService statisticsApiService)
        {
            _statisticsApiService = statisticsApiService;
        }

        public async Task<IActionResult> Index()
        {
            // Veriyi Servisten Çek
            var dto = await _statisticsApiService.GetDashboardAsync();

            // ViewModel'e Dönüştür
            var vm = dto.ToAdminStatisticsVm();

            return View(vm);
        }
    }
}
