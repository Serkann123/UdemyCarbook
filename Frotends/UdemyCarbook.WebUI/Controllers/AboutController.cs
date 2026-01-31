using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.Controllers
{
    public class AboutController : BaseController
    {
        public IActionResult Index()
        {
            SetPage("Hakkımızda", "Vizyonumuz & Misyonumuz");
            return View();
        }
    }
}
