using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.DefaultCoverComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial:ViewComponent
    {
        private readonly ICarApiService _carApiService;

        public _DefaultLast5CarsWithBrandsComponentPartial(ICarApiService carApiService)
        {
            _carApiService = carApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _carApiService.GetLast5CarsWithBrandAsync();
            return View(values);
        }
    }
}
