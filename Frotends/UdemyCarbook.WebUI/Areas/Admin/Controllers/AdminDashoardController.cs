using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminDashoard")]
    public class AdminDashoardController : Controller
    {
        [Route("Index")]
        public IActionResult Index(int page = 1)
        {
            ViewBag.CurrentPage = page;
            return View();
        }
    }
}