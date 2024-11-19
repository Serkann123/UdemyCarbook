using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
