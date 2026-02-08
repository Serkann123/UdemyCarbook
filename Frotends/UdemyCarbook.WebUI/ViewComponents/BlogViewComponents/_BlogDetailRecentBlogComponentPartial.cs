using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailRecentBlogComponentPartial:ViewComponent
    {
        private readonly IBlogApiService _blogApiService;

        public _BlogDetailRecentBlogComponentPartial(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _blogApiService.GetLast3WithAuthorsAsync();
            return View(values);
        }
    }
}
