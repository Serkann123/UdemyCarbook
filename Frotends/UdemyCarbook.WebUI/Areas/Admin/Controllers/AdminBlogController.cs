using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminBlogController : Controller
    {
        private readonly IBlogApiService _blogApiService;

        public AdminBlogController(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _blogApiService.GetBlogsAllWithAuthorsAsync();
            return View(values);
        }

        public async Task<IActionResult> RemoveBlog(int id)
        {
            var ok = await _blogApiService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");
            return View();
        }
    }
}