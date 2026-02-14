using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.WebUI.Extensions;
using UdemyCarbook.WebUI.ViewModels;

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
        public async Task<IActionResult> Index([FromQuery] BaseFilterRequest req)
        {
            var values = await _blogApiService.GetBlogsAllWithAuthorsAsync();
            var pagedList = values.ToFilteredPagedList(this, req,
               (x, search) =>
                   x.Title.Contains(search, StringComparison.OrdinalIgnoreCase)
                   || x.AuthorName.Contains(search, StringComparison.OrdinalIgnoreCase)
           );

            return View(pagedList);
        }

        public async Task<IActionResult> RemoveBlog(int id)
        {
            var ok = await _blogApiService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");
            return View();
        }
    }
}