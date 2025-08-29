using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarbook.Dto.CarFeatures;
using UdemyCarbook.Dto.FeatureDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly HttpClient client;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var responsMessage = await client.GetAsync("CarFeatures?id=" + id);
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdResultDto> getCarFeatureByCarIdResultDto)
        {
            foreach (var item in getCarFeatureByCarIdResultDto)
            {
                if (item.Available)
                {
                   
                    await client.GetAsync("CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureId);
                }

                else
                {
                   
                    await client.GetAsync("CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureId);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [HttpGet]
        public async Task<IActionResult> CreateCarFeatureByCar()
        {
            var responsMessage = await client.GetAsync("Features");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
