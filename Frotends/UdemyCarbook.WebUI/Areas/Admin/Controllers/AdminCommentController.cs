using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

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

        public async Task<IActionResult> Index()
        {
            var values = await _commentApiService.GetAllAsync();
            return View(values);
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
