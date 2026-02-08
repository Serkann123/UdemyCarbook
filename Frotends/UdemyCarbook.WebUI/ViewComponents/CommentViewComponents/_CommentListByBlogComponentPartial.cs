using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly ICommentApiService _commentApiService;

        public _CommentListByBlogComponentPartial(ICommentApiService commentApiService)
        {
            _commentApiService = commentApiService;
        }
        private List<string> GetImageUrls()
        {
            return new List<string>
            {
                "/carbook-master/images/person_1.jpg",
                "/carbook-master/images/person_2.jpg",
                "/carbook-master/images/person_3.jpg",
                "/carbook-master/images/person_4.jpg",
                "/carbook-master/images/person_5.jpg",
                "/carbook-master/images/person_6.jpg",
                "/carbook-master/images/person_7.jpg",
                "/carbook-master/images/person_8.jpg",
                "/carbook-master/images/person_9.jpg",
                "/carbook-master/images/person_10.png",
                "/carbook-master/images/person_11.jpeg",
                "/carbook-master/images/person_12.jpeg",
                "/carbook-master/images/person_13.jpeg",
                "/carbook-master/images/person_14.jpeg",
                "/carbook-master/images/person_15.jpeg",
                "/carbook-master/images/person_16.jpeg",
                "/carbook-master/images/person_17.jpeg",
            };
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogId = id;

            var values = await _commentApiService.GetByBlogIdAsync(id);

            List<string> imageUrls = GetImageUrls();
            Random rnd = new Random();

            foreach (var comment in values)
            {
                comment.ImageUrl = imageUrls[rnd.Next(imageUrls.Count)];
            }

            return View(values);
        }
    }
}
