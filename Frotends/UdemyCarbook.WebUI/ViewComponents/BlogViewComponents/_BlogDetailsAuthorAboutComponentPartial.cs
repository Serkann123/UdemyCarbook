using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial:ViewComponent
    {
        private readonly IBlogApiService _blogApiService;

        public _BlogDetailsAuthorAboutComponentPartial(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values = await _blogApiService.GetByAuthorIdAsync(id);
            return View(values);
        }
    }
}


