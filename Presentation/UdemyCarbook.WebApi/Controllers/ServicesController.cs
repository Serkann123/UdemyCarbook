using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.ServiceQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _meditor;

        public ServicesController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _meditor.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var values = await _meditor.Send(new GetServiceByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _meditor.Send(command);
            return Ok("Servis başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _meditor.Send(new RemoveServiceCommand(id));
            return Ok("Servis başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _meditor.Send(command);
            return Ok("Servis başarıyla güncelendi");
        }
    }
}
