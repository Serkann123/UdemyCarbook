using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Queries.CarPirincingQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarPrincingsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public CarPrincingsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarPirincingList()
        {
            var values = await _meditor.Send(new GetCarPirincingWithCarQuery());
            return Ok(values);
        }

        [HttpGet("GetCarPrincingWithTimePeriodQuery")]
        public async Task<IActionResult> GetCarPrincingWithTimePeriodQuery()
        {
            var values = await _meditor.Send(new GetCarPrincingWithTimePeriodQuery());
            return Ok(values);
        }
    }
}
