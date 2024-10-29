using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.LocationQueires;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    { 
        private readonly IMediator _meditor;

        public LocationsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            var values = await _meditor.Send(new GetLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLocation(int id)
        {
            var values = await _meditor.Send(new GetLocationByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _meditor.Send(command);
            return Ok("Lokasyon başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _meditor.Send(new RemoveLocationCommand(id));
            return Ok("Lokasyon başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _meditor.Send(command);
            return Ok("Lokasyon başarıyla güncelendi");
        }
    }
}
