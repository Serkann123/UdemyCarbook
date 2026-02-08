using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.DefaultCoverComponents
{
    public class _DefaultCoverComponentPartial:ViewComponent
    {
        private readonly IBannerApiService _bannerApiService;

        public _DefaultCoverComponentPartial(IBannerApiService bannerApiService)
        {
            _bannerApiService = bannerApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _bannerApiService.GetAllAsync();
            return View(values);
        }
    }
}
