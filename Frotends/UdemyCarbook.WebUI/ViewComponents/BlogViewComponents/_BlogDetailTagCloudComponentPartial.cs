using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailTagCloudComponentPartial : ViewComponent
    {
        private readonly ITagCloudApiService _tagCloudApiService;

        public _BlogDetailTagCloudComponentPartial(ITagCloudApiService tagCloudApiService)
        {
            _tagCloudApiService = tagCloudApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _tagCloudApiService.GetByBlogIdAsync(id);
            return View(values);
        }
    }
}
