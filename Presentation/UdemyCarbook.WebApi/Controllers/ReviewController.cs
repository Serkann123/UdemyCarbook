using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.ReviesQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetReviewByCarId")]
        public async Task<IActionResult> GetReviewByCarId(int id)
        {
            var values = await _mediator.Send(new GetReviewByCarIdQuery(id));
            return Ok(values);
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview(CreateReviewCommand command)
        {
            await _mediator.Send(command);
            return Ok("Ekleme işlemi yapıldı");
        }

        [HttpPut("UpdateReview")]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            await _mediator.Send(command);
            return Ok("Güncelleme işlemi yapıldı");
        }
    }
}
