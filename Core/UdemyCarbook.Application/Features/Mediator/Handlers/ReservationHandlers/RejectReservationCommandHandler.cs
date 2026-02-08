using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class RejectReservationCommandHandler : IRequestHandler<RejectReservationCommand, bool>
    {
        private readonly IRepository<Reservation> _repository;
        public RejectReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(RejectReservationCommand request, CancellationToken cancellationToken)
        {
            var res = await _repository.GetByIdAsync(request.ReservationId);

            if (res == null) return false;
            if (res.Status != "Pending") return false;

            res.Status = "Rejected";

            await _repository.UpdateAsync(res);

            return true;
        }
    }
}
