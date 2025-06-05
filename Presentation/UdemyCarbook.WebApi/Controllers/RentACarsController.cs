using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        public async Task<IActionResult> GetRentACarListByLocation(int locationId, bool avilable)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                Available = avilable,
                LocationId = locationId,
            };

            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        }
    }
}
