using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminContactController : Controller
    {
        private readonly IContactApiService _contactApiService;

        public AdminContactController(IContactApiService contactApiService)
        {
            _contactApiService = contactApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _contactApiService.GetAllAsync();
            return View(values);
        }

        public async Task<IActionResult> RemoveContact(int id)
        {
            var ok = await _contactApiService.RemoveAsync(id);
            if (ok) return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
