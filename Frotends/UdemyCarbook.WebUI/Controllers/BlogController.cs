using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CommentDtos;
using X.PagedList.Extensions;

namespace UdemyCarbook.WebUI.Controllers
{
    public class BlogController : BaseController
    {
        private readonly IBlogApiService _blogApiService;
        private readonly ICommentApiService _commentApiService;

        public BlogController(IBlogApiService blogApiService, ICommentApiService commentApiService)
        {
            _blogApiService = blogApiService;
            _commentApiService = commentApiService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            SetPage("Bloglar", "Yazarlarımızın Blogları");

            var values = await _blogApiService.GetBlogsAllWithAuthorsAsync();
            return View(values.ToPagedList(page, 12));
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            SetPage("Bloglar", "Blog Detayı ve Yorumlar");
            ViewBag.BlogId = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            var ok = await _commentApiService.CreateAsync(createCommentDto);
            if(ok) return RedirectToAction("Index","Default");
            return View();
        }
    }
}
