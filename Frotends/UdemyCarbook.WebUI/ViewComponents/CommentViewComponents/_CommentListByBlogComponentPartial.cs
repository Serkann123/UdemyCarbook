using Microsoft.AspNetCore.Mvc;

namespace UdemyCarbook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
