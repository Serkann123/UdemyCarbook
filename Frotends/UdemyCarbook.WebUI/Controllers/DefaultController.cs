using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UdemyCarbook.Application.Services;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ILocationApiService _locationApiService;

        public DefaultController(ILocationApiService locationApiService)
        {
            _locationApiService = locationApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _locationApiService.GetAllAsync();

            ViewBag.Locations = values.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.LocationId.ToString()
            }).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Index(RentSearchDto model)
        {
            return RedirectToAction("Index", "RentACarList", new
            {
                LocationId = model.LocationId,
                PickUp = model.PickUp,
                DropOff = model.DropOff
            });
        }
    }
}