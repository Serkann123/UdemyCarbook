using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Queries.CarDescriptionQueires;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionController : ControllerBase
    {
        private readonly IMediator _meditor;

        public CarDescriptionController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet("CarDetailByCarId")]
        public async Task<IActionResult> CarDetailByCarId(int id)
        {
            var values = await _meditor.Send(new GetCarDescriptionByCarIdQuery(id));
            return Ok(values);
        }
    }
}
