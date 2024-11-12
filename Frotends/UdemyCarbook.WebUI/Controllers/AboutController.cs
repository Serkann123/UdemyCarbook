using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
