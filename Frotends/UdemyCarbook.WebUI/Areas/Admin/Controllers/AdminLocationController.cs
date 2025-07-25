using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using UdemyCarbook.Dto.LocationDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminLocationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminLocationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Locations");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateLocation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationDto createLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PostAsync("https://localhost:7126/api/Locations", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> RemoveLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"https://localhost:7126/api/Locations/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateLocation(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsMessage = await client.GetAsync($"https://localhost:7126/api/Locations/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateLocationDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLocation(UpdateLocationDto updateLocationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateLocationDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7126/api/Locations/", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminLocation", new { area = "Admin" });
            }
            return View();
        }
    }
}