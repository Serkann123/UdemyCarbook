using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.CarDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Cars/GetCarWithBrand");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
