using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using UdemyCarbook.Application.Validators.Tools;
using UdemyCarbook.Dto.LocationDtos;
using UdemyCarbook.Dto.ReservationDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly HttpClient client;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";

            ViewBag.v3 = id;
           
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
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            ViewBag.v1 = "Araç Kiralama";
            ViewBag.v2 = "Araç Rezervasyon Formu";
            ViewBag.v3 = createReservationDto.CarId;

            if (!ModelState.IsValid)
            {
                await LoadLocations();
                return View(createReservationDto);
            }

            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("Reservations", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "Default");

            await AddApiErrorsToModelState(responseMessage);

            await LoadLocations();
            return View(createReservationDto);
        }

        private async Task LoadLocations()
        {
            var responsMessage = await client.GetAsync("Locations");
            var jsonData = await responsMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData) ?? new();

            ViewBag.Locations = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString()
            }).ToList();
        }

        private async Task AddApiErrorsToModelState(HttpResponseMessage responseMessage)
        {
            var body = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorResponse = JsonConvert.DeserializeObject<ApiValidationProblem>(body);

                if (errorResponse?.Errors != null)
                {
                    foreach (var error in errorResponse.Errors)
                    {
                        foreach (var message in error.Value)
                            ModelState.AddModelError(error.Key, message);
                    }
                    return;
                }
            }
            ModelState.AddModelError(string.Empty, $"İşlem başarısız: {(int)responseMessage.StatusCode} {responseMessage.ReasonPhrase}");
        }
    }
}