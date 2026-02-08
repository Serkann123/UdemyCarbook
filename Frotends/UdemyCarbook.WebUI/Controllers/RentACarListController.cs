using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.WebUI.Controllers
{
    public class RentACarListController : BaseController
    {
        private readonly IRentACarApiService _rentACarApiService;

        public RentACarListController(IRentACarApiService rentACarApiService)
        {
            _rentACarApiService = rentACarApiService;
        }

        public async Task<IActionResult> Index(RentSearchDto model)
        {
            SetPage("Araçlarımız", "Seçiminize Uygun Araçlar");


            // Rezervasyon formundaki input alanlarını seçilen değerlerle doldurmak için
            ViewBag.locationId = model.LocationId;
            ViewBag.pickUp = model.PickUp.ToString("yyyy-MM-ddTHH:mm");
            ViewBag.dropOff = model.DropOff.ToString("yyyy-MM-ddTHH:mm");

            var values = await _rentACarApiService.GetAvailableAsync(model);
            return View(values);
        }
    }
}

