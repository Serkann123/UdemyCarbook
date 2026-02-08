using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDescriptionByCarIdComponenetPartial:ViewComponent
    {
        private readonly ICarApiService _carApiService;

        public _CarDescriptionByCarIdComponenetPartial(ICarApiService carApiService)
        {
            _carApiService = carApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var value = await _carApiService.GetDescriptionByCarIdAsync(id);
            return View(value);
        }
    }
}
