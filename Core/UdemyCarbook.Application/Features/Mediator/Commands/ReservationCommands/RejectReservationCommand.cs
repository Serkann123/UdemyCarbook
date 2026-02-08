using MediatR;

namespace UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands
{
    public class RejectReservationCommand : IRequest<bool>
    {
        public int ReservationId { get; set; }
    }
}
