using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogLast3WithAuthorListComponentPartial:ViewComponent
    {
        private readonly IBlogApiService _blogApiService;

        public _BlogLast3WithAuthorListComponentPartial(IBlogApiService blogApiService)
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
