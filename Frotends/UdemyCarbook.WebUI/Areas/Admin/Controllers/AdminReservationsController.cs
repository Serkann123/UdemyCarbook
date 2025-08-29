using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.ReservationDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminReservationsController : Controller
    {
        private readonly HttpClient client;

        public AdminReservationsController(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseMessage= await client.GetAsync("Reservations");
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
