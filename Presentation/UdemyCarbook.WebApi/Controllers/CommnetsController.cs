using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.RepositoryPattern;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommnetsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;

        public CommnetsController(IGenericRepository<Comment> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult CommnentList()
        {
            var values = _repository.GetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveComment(int id)
        {
            var value=_repository.GetById(id);
            _repository.Remove(value);
            return Ok("Yorum başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateComment(Comment comment)
        {
            _repository.Update(comment);
            return Ok("Yorum başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _repository.GetById(id);
            return Ok(values);
        }

        [HttpGet("CommentListByBlog")]
        public async Task<IActionResult> CommentListByBlog(int id)
        {
            var values = _repository.GetCommentsByBlogId(id);
            return Ok(values);
        }

        [HttpGet("CommentCountByBlog")]
        public async Task<IActionResult> CommentCountByBlog(int id)
        {
            var value = _repository.GetCountCommentBlog(id);
            return Ok(value);
        }
    }
}
