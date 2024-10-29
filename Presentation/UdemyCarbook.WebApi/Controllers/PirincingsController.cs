using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.PirincingCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.PirincingQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PirincingsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public PirincingsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> PiricingList()
        {
            var values = await _meditor.Send(new GetPirincingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPiricing(int id)
        {
            var values = await _meditor.Send(new GetPirincingByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePiricing(CreatePirincingCommand command)
        {
            await _meditor.Send(command);
            return Ok("Ödeme Türü başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddrss(int id)
        {
            await _meditor.Send(new RemovePirincingCommand(id));
            return Ok("Ödeme Türü başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePiricing(UpdatePirincingCommand command)
        {
            await _meditor.Send(command);
            return Ok("Ödeme Türü başarıyla güncelendi");
        }
    }
}
