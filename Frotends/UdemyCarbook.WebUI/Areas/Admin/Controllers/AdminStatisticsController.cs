using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.StatisticsDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCount");
            if (responsMessage.IsSuccessStatusCode)
            {
                int sayi = random.Next(0,101);
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.CarCount;
                ViewBag.v1 = sayi;
            }

            var responsMessage2 = await client.GetAsync("https://localhost:7126/api/Statistics/GetLocationQuery");
            if (responsMessage2.IsSuccessStatusCode)
            {
                int sayi2 = random.Next(0, 101);
                var jsonData2 = await responsMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.LocationCount = values2.LocationCount;
                ViewBag.LocationCountRandom = sayi2;
            }

            return View();
        }
    }
}
