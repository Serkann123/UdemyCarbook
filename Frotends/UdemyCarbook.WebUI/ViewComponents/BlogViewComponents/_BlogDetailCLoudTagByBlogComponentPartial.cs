using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCLoudTagByBlogComponentPartial : ViewComponent
    {
        private readonly ITagCloudApiService _tagCloudApiService;

        public _BlogDetailCLoudTagByBlogComponentPartial(ITagCloudApiService tagCloudApiService)
        {
            _tagCloudApiService = tagCloudApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _tagCloudApiService.GetByBlogIdAsync(id);
            var limitedValues = values.Take(10).ToList();
            return View(limitedValues);
        }
    }
}
