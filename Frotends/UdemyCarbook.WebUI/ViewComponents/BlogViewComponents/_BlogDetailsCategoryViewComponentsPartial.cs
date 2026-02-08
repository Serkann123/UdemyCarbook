using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsCategoryViewComponentsPartial : ViewComponent
    {
        private readonly ICategoryApiService _categoryApiService;

        public _BlogDetailsCategoryViewComponentsPartial(ICategoryApiService categoryApiService)
        {
            _categoryApiService = categoryApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryApiService.GetAllAsync();

            var randomCategories = values
                .OrderBy(_ => Guid.NewGuid())
                .Take(10)
                .ToList();

            return View(randomCategories);
        }
    }
}