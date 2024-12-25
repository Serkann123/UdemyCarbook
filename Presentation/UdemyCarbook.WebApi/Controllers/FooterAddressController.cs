using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using UdemyCarbook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _meditor;

        public FooterAddressController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var values = await _meditor.Send(new GetFooterAddressQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var values = await _meditor.Send(new GetFooterAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _meditor.Send(command);
            return Ok("Adres bilgisi başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _meditor.Send(new RemoveFooterAddressComamnd(id));
            return Ok("Adres bilgisi başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _meditor.Send(command);
            return Ok("Adres bilgisi başarıyla güncelendi");
        }

    }
}

