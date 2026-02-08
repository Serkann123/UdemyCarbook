using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.ServiceVİewComponents
{
    public class _ServiceComponentParital : ViewComponent
    {
        private readonly IServiceApiService _serviceApiService;

        public _ServiceComponentParital(IServiceApiService serviceApiService)
        {
            _serviceApiService = serviceApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _serviceApiService.GetAllAsync();
            return View(values);
        }
    }
}
