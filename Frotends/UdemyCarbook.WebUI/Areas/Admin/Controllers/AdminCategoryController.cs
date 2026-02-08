using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CategoryDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryApiService _categoryApiService;

        public AdminCategoryController(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _categoryApiService.GetAllAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var ok = await _categoryApiService.CreateAsync(createCategoryDto);
            if (ok)
                return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });

            return View(createCategoryDto);
        }

        public async Task<IActionResult> RemoveCategory(int id)
        {
            var ok = await _categoryApiService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var value = await _categoryApiService.GetByIdAsync(id);
            if (value is null) return RedirectToAction("Index");

            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var ok = await _categoryApiService.UpdateAsync(updateCategoryDto);
            if (ok)
                return RedirectToAction("Index", "AdminCategory", new { area = "Admin" });

            return View(updateCategoryDto);
        }
    }
}
