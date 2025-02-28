using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.BlogDtos;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class CarPrincingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarPrincingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/CarPrincings/GetCarPrincingWithTimePeriodQuery");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPrincingListModelDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
