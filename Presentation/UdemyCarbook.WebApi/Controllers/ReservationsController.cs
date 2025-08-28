using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.ReservationQueries;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _meditor;

        public ReservationsController(IMediator meditor)
        {
            _meditor = meditor;
        }

        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var values = await _meditor.Send(new GetReservationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation(int id)
        {
            var values = await _meditor.Send(new GetReservationByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _meditor.Send(command);
            return Ok("Rezervayon başarıyla yapıldı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveReservation(int id)
        {
            await _meditor.Send(new RemoveReservationCommand(id));
            return Ok("Rezervayon başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation(UpdateReservationCommand command)
        {
            await _meditor.Send(command);
            return Ok("Rezervayon başarıyla güncelendi");
        }
    }
}