using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.AuthorDtos;
using UdemyCarbook.WebUI.Extensions;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminAuthorController : Controller
    {
        private readonly IAuthorApiService _authorApiService;

        public AdminAuthorController(IAuthorApiService authorApiService)
        {
            _authorApiService = authorApiService;
        }

        public async Task<IActionResult> Index([FromQuery] BaseFilterRequest req)
        {
            var values = await _authorApiService.GetAllAsync();
            var pagedList = values.ToFilteredPagedList(this, req,
                 (x, search) => x.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

            return View(pagedList);
        }

        [HttpGet]
        public ActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            var ok = await _authorApiService.CreateAsync(createAuthorDto);
            if (ok)
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });

            return View(createAuthorDto);
        }

        public async Task<IActionResult> RemoveAuthor(int id)
        {
            var ok = await _authorApiService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAuthor(int id)
        {
            var value = await _authorApiService.GetByIdAsync(id);
            if (value is null) return RedirectToAction("Index");

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAuthor(UpdateAuthorDto updateAuthorDto)
        {
            var ok = await _authorApiService.UpdateAsync(updateAuthorDto);
            if (ok)
                return RedirectToAction("Index", "AdminAuthor", new { area = "Admin" });

            return View(updateAuthorDto);
        }
    }
}