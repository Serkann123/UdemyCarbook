using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Application.Validators.Tools;
using UdemyCarbook.Dto.ServiceDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminServiceController : Controller
    {
        private readonly IServiceApiService _serviceApiService;

        public AdminServiceController(IServiceApiService serviceApiService)
        {
            _serviceApiService = serviceApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _serviceApiService.GetAllAsync();
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
            var (ok, response) = await _serviceApiService.CreateAsync(dto);

            if (ok)
                return RedirectToAction(nameof(Index), "AdminService", new { area = "Admin" });

            if (response is not null)
                await AddApiErrorsToModelState(response);

            return View(dto);
        }

        public async Task<IActionResult> RemoveService(int id)
        {
            var ok = await _serviceApiService.RemoveAsync(id);
            if (ok)
                return RedirectToAction(nameof(Index));
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateService(int id)
        {
            var value = await _serviceApiService.GetByIdAsync(id);
            if (value is null) return View();

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDto dto)
        {
            var (ok, response) = await _serviceApiService.UpdateAsync(dto);

            if (ok)
                return RedirectToAction(nameof(Index), "AdminService", new { area = "Admin" });

            if (response is not null)
                await AddApiErrorsToModelState(response);

            return View(dto);
        }

        private async Task AddApiErrorsToModelState(HttpResponseMessage responseMessage)
        {
            var body = await responseMessage.Content.ReadAsStringAsync();

            if (responseMessage.StatusCode == HttpStatusCode.BadRequest)
            {
                var errorResponse = JsonConvert.DeserializeObject<ApiValidationProblemDto>(body);

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
