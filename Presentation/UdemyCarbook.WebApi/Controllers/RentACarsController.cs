using MediatR;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Queries.RentACarQueiries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("available")]
        public async Task<IActionResult> Available( [FromQuery] GetAvailableRentACarsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
