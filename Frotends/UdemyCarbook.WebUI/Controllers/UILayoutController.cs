using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
