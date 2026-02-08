using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCommentCarByIdComponentPartial : ViewComponent
    {
        private readonly IReviewApiService _reviewApiService;

        public _CarDetailCommentCarByIdComponentPartial(IReviewApiService reviewApiService)
        {
            _reviewApiService = reviewApiService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _reviewApiService.GetByCarIdAsync(id);

            ViewBag.five = values.Count(x => x.RaytingValue == 5);
            ViewBag.four = values.Count(x => x.RaytingValue == 4);
            ViewBag.three = values.Count(x => x.RaytingValue == 3);
            ViewBag.two = values.Count(x => x.RaytingValue == 2);
            ViewBag.one = values.Count(x => x.RaytingValue == 1);

            var total = values.Count();

            ViewBag.fivetotal = total == 0 ? 0 : values.Count(x => x.RaytingValue == 5) * 100.0 / total;
            ViewBag.fourtotal = total == 0 ? 0 : values.Count(x => x.RaytingValue == 4) * 100.0 / total;
            ViewBag.threetotal = total == 0 ? 0 : values.Count(x => x.RaytingValue == 3) * 100.0 / total;
            ViewBag.twototal = total == 0 ? 0 : values.Count(x => x.RaytingValue == 2) * 100.0 / total;
            ViewBag.onetotal = total == 0 ? 0 : values.Count(x => x.RaytingValue == 1) * 100.0 / total;

            return View(values);
        }
    }
}
