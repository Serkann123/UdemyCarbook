using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservertionsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public ReservertionsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpPost]
        public async Task<IActionResult> Handle(CreateReservationCommand command)
        {
            await _meditor.Send(command);
            return Ok("Rezervayon işlemi başarıyla yapıldı");
        }
    }
}