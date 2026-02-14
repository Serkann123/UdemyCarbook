using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.WebUI.Extensions;
using UdemyCarbook.WebUI.ViewModels;

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

        public async Task<IActionResult> Index([FromQuery] BaseFilterRequest req)
        {
            var values = await _contactApiService.GetAllAsync();

            var pagedList = values.ToFilteredPagedList(this, req,
                (x, search) =>
                    (x.Name ?? "").Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (x.Subject ?? "").Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (x.Email ?? "").Contains(search, StringComparison.OrdinalIgnoreCase)
            );

            return View(pagedList);
        }

        public async Task<IActionResult> RemoveContact(int id)
        {
            var ok = await _contactApiService.RemoveAsync(id);
            if (ok) return RedirectToAction(nameof(Index));

            return View();
        }
    }
}
