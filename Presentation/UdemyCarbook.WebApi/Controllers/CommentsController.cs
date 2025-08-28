using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.CommentQueires;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public CommentsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> CommnentList()
        {
            var values =await _meditor.Send(new GetCommentQuery());
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommannd command)
        {
            await _meditor.Send(command);
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _meditor.Send(new RemoveCommentCommand(id));
            return Ok("Yorum başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            await _meditor.Send(command);
            return Ok("Yorum başarıyla güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var values = await _meditor.Send(new GetCommentByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CommentListByBlog")]
        public async Task<IActionResult> CommentListByBlog(int id)
        {
            var values =await _meditor.Send(new GetCommentListByBlogIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CommentCountByBlog")]
        public async Task<IActionResult> CommentCountByBlog(int id)
        {
            var value = await _meditor.Send(new GetCountCommentBlogQuery(id));
            return Ok(value);
        }
    }
}
