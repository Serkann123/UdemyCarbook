using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarbook.Dto.SocialMediaDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminSocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminSocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/SocialMedias");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PostAsync("https://localhost:7126/api/SocialMedias", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            return View();
        }

        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.DeleteAsync($"https://localhost:7126/api/SocialMedias/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responsMessage = await client.GetAsync($"https://localhost:7126/api/SocialMedias/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responsMessage = await client.PutAsync("https://localhost:7126/api/SocialMedias/", stringContent);
            if (responsMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminSocialMedia", new { area = "Admin" });
            }
            return View();
        }
    }
}