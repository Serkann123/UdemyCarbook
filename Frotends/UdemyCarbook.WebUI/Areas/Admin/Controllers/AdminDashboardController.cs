using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BlogListPartial(int page = 1)
        {
            return ViewComponent("_AdminDashboardBlogListComponentPartial", new { page });
        }

    }
}