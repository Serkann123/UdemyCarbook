using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using X.PagedList.Extensions;

namespace UdemyCarbook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardBlogListComponentPartial : ViewComponent
    {
        private readonly IBlogApiService _blogApiService;
        public _AdminDashboardBlogListComponentPartial(IBlogApiService blogApiService)
        {
            _blogApiService = blogApiService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int page = 1)
        {

            var values = await _blogApiService.GetBlogsAllWithAuthorsAsync();
            var pagedValues = values.ToPagedList(page, 4);

            return View(pagedValues);
        }
    }
}
