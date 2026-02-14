using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.WebUI.Extensions;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        private readonly ICommentApiService _commentApiService;
        public AdminCommentController(ICommentApiService commentApiService)
        {
            _commentApiService = commentApiService;
        }

        public async Task<IActionResult> Index([FromQuery] BaseFilterRequest req)
        {
            var values = await _commentApiService.GetAllAsync();

            var pagedList = values.ToFilteredPagedList(this, req,
                (x, search) =>
                    (x.Name ?? "").Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (x.Email ?? "").Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    (x.Description ?? "").Contains(search, StringComparison.OrdinalIgnoreCase)
            );

            return View(pagedList);
        }

        public async Task<IActionResult> RemoveComment(int id)
        {
            var ok = await _commentApiService.RemoveAsync(id);
            if (ok) return RedirectToAction("Index");
            return View();
        }

        public async Task<IActionResult> BlogComments(int id)
        {
            var values = await _commentApiService.GetByBlogIdAsync(id);
            return View(values);
        }
    }
}
