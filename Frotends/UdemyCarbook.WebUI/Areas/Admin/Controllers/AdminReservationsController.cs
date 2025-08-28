using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.ReservationDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminReservationsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReservationsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = _httpClientFactory.CreateClient();
            HttpResponseMessage responseMessage= await client.GetAsync("https://localhost:7126/api/Reservations");
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsonData);
                return View(values);
            }
                return View();
        }
    }
}
