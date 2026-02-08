using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial:ViewComponent
    {
        private readonly ICarApiService _carApiService;

        public _CarDetailMainCarFeatureComponentPartial(ICarApiService carApiService)
        {
            _carApiService = carApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _carApiService.GetMainCarFeatureAsync(id);
            return View(value);
        }
    }
}
