using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;
using UdemyCarbook.Dto.LocationDtos;
using UdemyCarbook.Dto.ReservationDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        // Dropdown verilerini doldurmak için yardımcı metot
        private async Task PopulateLocationsAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7126/api/Locations");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            List<SelectListItem> selectList = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString()
            }).ToList();

            ViewBag.v = selectList;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";

            await PopulateLocationsAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            // Model geçersizse dropdown'ları yeniden doldurmalısınız.
            if (!ModelState.IsValid)
            {
                await PopulateLocationsAsync();
                return View(createReservationDto);
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7126/api/Reservertions", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }

            // API çağrısında hata varsa, dropdown verilerini yeniden doldurun.
            await PopulateLocationsAsync();
            ModelState.AddModelError("", "Rezervasyon oluşturulurken bir hata oluştu.");
            return View(createReservationDto);
        }
    }
}
