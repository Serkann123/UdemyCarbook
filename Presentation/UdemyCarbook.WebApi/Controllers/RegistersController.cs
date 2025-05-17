using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.AppUserCommands;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly IMediator _meditor;

        public RegistersController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateAppUserCommand command)
        {
            await _meditor.Send(command);
            return Ok("Kullanıcı başarıyla oluşturuldu");
        }
    }
}
