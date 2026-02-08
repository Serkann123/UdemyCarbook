using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminReservationController : Controller
    {
        private readonly IReservationApiService _reservationApiService;

        public AdminReservationController(IReservationApiService reservationApiService)
        {
            _reservationApiService = reservationApiService;
        }

        public async Task<IActionResult> Pending()
        {
            var values = await _reservationApiService.GetPendingReservationsAsync();
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            await _reservationApiService.ApproveAsync(id);
            return RedirectToAction(nameof(Pending));
        }

        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            await _reservationApiService.RejectAsync(id);
            return RedirectToAction(nameof(Pending));
        }
    }
}
