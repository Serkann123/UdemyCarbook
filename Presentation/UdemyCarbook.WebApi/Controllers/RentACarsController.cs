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
        public async Task<IActionResult> GetRentACarListByLocation(string LocationId,bool avilable)
        {
            GetRentACarQuery getRentACarQuery = new GetRentACarQuery()
            {
                LocationId = int.Parse(LocationId.ToString()),
                Available = avilable
            };

            var values = await _mediator.Send(getRentACarQuery);
            return Ok(values);
        } 
    }
}
