using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Controllers
{
    public class ServiceController : BaseController
    {
        public IActionResult Index()
        {
            SetPage("Hizmetler", "Hizmetlerimiz");
            return View();
        }
    }
}
