using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainCompenentPartial : ViewComponent
    {
        private readonly IBlogApiService _blogApiService;
        private readonly ICommentApiService _commentApiService;

        public _BlogDetailsMainCompenentPartial(IBlogApiService blogApiService,
            ICommentApiService commentApiService)
        {
            _blogApiService = blogApiService;
            _commentApiService = commentApiService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var blog = await _blogApiService.GetByIdAsync(id);
            if (blog is null) return View();

            var countDto = await _commentApiService.GetCountByBlogIdAsync(id);
            ViewBag.commentCount = countDto?.CommentBlogCount ?? 0;

            return View(blog);
        }
    }
}
