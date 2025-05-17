using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
