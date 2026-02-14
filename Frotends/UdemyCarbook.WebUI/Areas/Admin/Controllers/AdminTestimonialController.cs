using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.TestimonialDtos;
using UdemyCarbook.WebUI.Extensions;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminTestimonialController : Controller
    {
        private readonly ITestimonialApiService _testimonialApiService;

        public AdminTestimonialController(ITestimonialApiService testimonialApiService)
        {
            _testimonialApiService = testimonialApiService;
        }
        public async Task<IActionResult> Index([FromQuery] BaseFilterRequest req)
        {
            var values = await _testimonialApiService.GetAllAsync();

            var pagedList = values.ToFilteredPagedList(this, req,
                (x, search) => x.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

            return View(pagedList);
        }

        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            var ok = await _testimonialApiService.CreateAsync(dto);
            if (ok)
                return RedirectToAction(nameof(Index), "AdminTestimonial", new { area = "Admin" });

            return View(dto);
        }
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            await _testimonialApiService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _testimonialApiService.GetByIdAsync(id);
            if (value is null) return View();

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            var ok = await _testimonialApiService.UpdateAsync(dto);
            if (ok)
                return RedirectToAction(nameof(Index), "AdminTestimonial", new { area = "Admin" });

            return View(dto);
        }
    }
}
