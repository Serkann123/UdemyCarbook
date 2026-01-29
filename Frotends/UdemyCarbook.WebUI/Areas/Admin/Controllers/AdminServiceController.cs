using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using UdemyCarbook.Application.Validators.Tools;
using UdemyCarbook.Dto.ServiceDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminServiceController : Controller
    {
        private readonly HttpClient client;

        public AdminServiceController(IHttpClientFactory httpClientFactory)
        {
            client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await client.GetAsync("Services");
            if (!responseMessage.IsSuccessStatusCode) return View();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateService()
        {
            return View(new CreateServiceDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("Services", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });

            await AddApiErrorsToModelState(responseMessage);
            return View(dto);
        }

        public async Task<IActionResult> RemoveService(int id)
        {
            var responseMessage = await client.DeleteAsync($"Services/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index");

            ModelState.AddModelError(string.Empty, "Silme işlemi başarısız.");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var responseMessage = await client.GetAsync($"Services/{id}");
            if (!responseMessage.IsSuccessStatusCode) return View();

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
        {
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("Services", stringContent);

            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "AdminService", new { area = "Admin" });

            await AddApiErrorsToModelState(responseMessage);
            return View(dto);
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
