using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.ReservationQueries;
using UdemyCarbook.Application.Features.Mediator.Results.ReservationResults;
using UdemyCarbook.Application.Interfaces.ReservationInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetPendingReservationsQueryHandler : IRequestHandler<GetPendingReservationsQuery, List<GetPendingReservationQueryResult>>
    {
        private readonly IReservationRepository _reservationRepository;

        public GetPendingReservationsQueryHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        public async Task<List<GetPendingReservationQueryResult>> Handle(GetPendingReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetPendingAsync();

            return reservations.Select(x => new GetPendingReservationQueryResult
            {
                ReservationId = x.ReservationId,
                Name = x.Name,
                Surname = x.Surname,
                CarId = x.CarId,
                CarName = x.Car.Brand.Name + " " + x.Car.Model,
                PickUpDateTime = x.PickUpDateTime,
                DropOffDateTime = x.DropOffDateTime,
                Status = x.Status
            }).ToList();
        }
    }
}
