using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using UdemyCarbook.Dto.LocationDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var token = User.Claims.FirstOrDefault(x=>x.Type== "accessToken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
                var responsMessage = await client.GetAsync("https://localhost:7126/api/Locations");
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

                List<SelectListItem> values2 = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.LocationId.ToString()
                                                }).ToList();

                ViewBag.v = values2;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string book_pick_date, string book_off_date, string time_pick, string time_off, string locationId)
        {
            TempData["bookpickdate"] = book_pick_date;
            TempData["bookofdate"] = book_off_date;
            TempData["timepick"] = time_pick;
            TempData["timeoff"] = time_off;
            TempData["locationId"] = locationId;

            return RedirectToAction("Index", "RentACarList");
        }
    }
}