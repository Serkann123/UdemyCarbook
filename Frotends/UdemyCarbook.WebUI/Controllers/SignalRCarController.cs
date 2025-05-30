using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
