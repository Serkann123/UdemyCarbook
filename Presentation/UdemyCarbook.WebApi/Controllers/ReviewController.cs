using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.ReviesQueries;
using UdemyCarbook.Application.Validators;

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
            CreateReviewValidator valitor = new CreateReviewValidator();
            var validatorResult = valitor.Validate(command);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            await _mediator.Send(command);
            return Ok("Ekleme işlemi yapıldı");
        }

        [HttpPut("UpdateReview")]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand command)
        {
            UpdateReviewValidator valitor = new UpdateReviewValidator();
            var validatorResult = valitor.Validate(command);
            if (!validatorResult.IsValid)
            {
                return BadRequest(validatorResult.Errors);
            }

            await _mediator.Send(command);
            return Ok("Güncelleme işlemi yapıldı");
        }
    }
}
