using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class CarPrincingController : Controller
    {
        private readonly HttpClient client;

        public CarPrincingController(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Paketler";
            ViewBag.v2 = "Araç Fiyat Paketleri";
           
            var responsMessage = await client.GetAsync("CarPrincings/GetCarPrincingWithTimePeriodQuery");
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
