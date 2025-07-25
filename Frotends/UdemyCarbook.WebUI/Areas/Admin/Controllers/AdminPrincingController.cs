using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarbook.Dto.PirincingDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminPrincingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminPrincingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Pirincings");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreatePrincing()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrincing(CreatePrincingDto createPrincingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPrincingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PostAsync("https://localhost:7126/api/Pirincings", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPrincing", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> RemovePrincing(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"https://localhost:7126/api/Pirincings/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePrincing(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsMessage = await client.GetAsync($"https://localhost:7126/api/Pirincings/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdatePrincingDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePrincing(UpdatePrincingDto updatePrincingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updatePrincingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7126/api/Pirincings/", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminPrincing", new { area = "Admin" });
            }
            return View();
        }
    }
}
