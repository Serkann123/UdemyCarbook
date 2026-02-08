using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonialApiService _testimonialApiService;

        public _TestimonialComponentPartial(ITestimonialApiService testimonialApiService)
        {
            _testimonialApiService = testimonialApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _testimonialApiService.GetAllAsync();
            return View(values);
        }
    }
}
