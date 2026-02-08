using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial:ViewComponent
    {
        private readonly IFooterAddressApiService _footerAddressApiService;

        public _FooterAddressComponentPartial(IFooterAddressApiService footerAddressApiService)
        {
            _footerAddressApiService = footerAddressApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _footerAddressApiService.GetByIdAsync(1);
            return View(value);
        }
    }
}
