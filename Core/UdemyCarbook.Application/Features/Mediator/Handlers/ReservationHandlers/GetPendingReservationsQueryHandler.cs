using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.ReservationQueries;
using UdemyCarbook.Application.Features.Mediator.Results.ReservationResults;
using UdemyCarbook.Application.Interfaces.ReservationInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetPendingReservationsQueryHandler : IRequestHandler<GetPendingReservationsQuery, List<GetPendingReservationQueryResult>>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;
        public GetPendingReservationsQueryHandler(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPendingReservationQueryResult>> Handle(GetPendingReservationsQuery request, CancellationToken cancellationToken)
        {
            var reservations = await _reservationRepository.GetPendingAsync();
            return _mapper.Map<List<GetPendingReservationQueryResult>>(reservations);
        }
    }
}
