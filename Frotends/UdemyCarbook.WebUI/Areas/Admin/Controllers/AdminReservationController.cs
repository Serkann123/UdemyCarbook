using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.WebUI.Extensions;
using UdemyCarbook.WebUI.ViewModels;

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
        public async Task<IActionResult> Pending([FromQuery] BaseFilterRequest req)
        {
            var values = await _reservationApiService.GetPendingReservationsAsync();

            var pagedList = values.ToFilteredPagedList(this, req, (x, search) =>
                ($"{x.Name} {x.Surname}").Contains(search, StringComparison.OrdinalIgnoreCase)
                || (x.CarName ?? "").Contains(search, StringComparison.OrdinalIgnoreCase)
                || (x.Status ?? "").Contains(search, StringComparison.OrdinalIgnoreCase)
            );

            return View(pagedList);
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
