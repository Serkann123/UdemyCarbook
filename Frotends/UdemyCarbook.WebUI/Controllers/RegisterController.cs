using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.RegisterDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterApiService _registerApiService;

        public RegisterController(IRegisterApiService registerApiService)
        {
            _registerApiService = registerApiService;
        }

        public IActionResult CreateAppUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateRegisterDto dto)
        {
            var ok = await _registerApiService.CreateUserAsync(dto);

            if (ok)
                return RedirectToAction("Index", "Login");

            return View(dto);
        }
    }
}
