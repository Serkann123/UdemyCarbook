using MediatR;

namespace UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands
{
    public class ApproveReservationCommand : IRequest<bool>
    {
        public int ReservationId { get; set; }
    }
}
