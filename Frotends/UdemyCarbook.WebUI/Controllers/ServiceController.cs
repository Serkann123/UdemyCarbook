using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace UdemyCarbook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
