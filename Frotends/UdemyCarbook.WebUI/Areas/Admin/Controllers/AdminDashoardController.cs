using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminDashoardController : Controller
    {
        public IActionResult Index(int page = 1)
        {
            ViewBag.CurrentPage = page;
            return View();
        }
    }
}