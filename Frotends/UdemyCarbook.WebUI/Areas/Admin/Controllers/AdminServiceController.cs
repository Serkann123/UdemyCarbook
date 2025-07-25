using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarbook.Dto.ServiceDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Services");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PostAsync("https://localhost:7126/api/Services", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
            return View();
        }
        public async Task<IActionResult> RemoveService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"https://localhost:7126/api/Services/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsMessage = await client.GetAsync($"https://localhost:7126/api/Services/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7126/api/Services/", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });
            }
            return View();
        }
    }
}