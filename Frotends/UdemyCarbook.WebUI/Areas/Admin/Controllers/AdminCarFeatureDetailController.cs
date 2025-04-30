using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarbook.Dto.BlogDtos;
using UdemyCarbook.Dto.CarFeatures;
using UdemyCarbook.Dto.CategoryDtos;
using UdemyCarbook.Dto.FeatureDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/CarFeatures?id=" + id);
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdResultDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdResultDto> getCarFeatureByCarIdResultDto)
        {

            foreach (var item in getCarFeatureByCarIdResultDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7126/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureId);
                }

                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7126/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureId);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }

        [Route("CreateCarFeatureByCar")]
        [HttpGet]
        public async Task<IActionResult> CreateCarFeatureByCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Features");
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
