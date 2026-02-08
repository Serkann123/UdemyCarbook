using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailCarFeatureByCarIdComponentPartial:ViewComponent
    {
        private readonly ICarFeatureApiService _carFeatureApiService;

        public _CarDetailCarFeatureByCarIdComponentPartial(ICarFeatureApiService carFeatureApiService)
        {
            _carFeatureApiService = carFeatureApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _carFeatureApiService.GetByCarIdAsync(id);
            return View(values);
        }
    }
}
