using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutUsComponentPartial : ViewComponent
    {
        private readonly IAboutApiService _aboutApiService;
        public _AboutUsComponentPartial(IAboutApiService aboutApiService)
        {
            _aboutApiService = aboutApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutApiService.GetAllAsync();
            return View(values);
        }
    }
}
