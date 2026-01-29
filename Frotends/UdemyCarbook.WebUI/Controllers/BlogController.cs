using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogApiService _blogApiService;
        private readonly ICommentApiService _commentApiService;

        public BlogController(IBlogApiService blogApiService, ICommentApiService commentApiService)
        {
            _blogApiService = blogApiService;
            _commentApiService = commentApiService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Yazarlarımızın Blogları";

            var values = await _blogApiService.GetBlogsAllWithAuthorsAsync();
            return View(values);
        }

        public async Task<IActionResult> BlogDetail(int id)
        {
            ViewBag.v1 = "Bloglar";
            ViewBag.v2 = "Blog Detayı ve Yorumlar";
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
