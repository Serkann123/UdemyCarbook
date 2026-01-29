using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using UdemyCarbook.Dto.LocationDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly HttpClient client;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var responsMessage = await client.GetAsync("Locations");
            var jsonData = await responsMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

            ViewBag.Locations = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Index(int locationId)
        {
            TempData["locationId"] = locationId;
            return RedirectToAction("Index", "RentACarList");
        }
    }
}