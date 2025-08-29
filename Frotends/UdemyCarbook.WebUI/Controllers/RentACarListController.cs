using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.RentACarFilterDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly HttpClient client;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Seçiminize Uygun Araçlar";

            var locationId = TempData["locationId"];

            var id = locationId != null ? int.Parse(locationId.ToString()) : 0;
           
            var responsMessage = await client.GetAsync($"https://localhost:7126/api/RentACars?locationId={id}&available=true");

            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}