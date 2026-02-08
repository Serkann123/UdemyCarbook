
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Results.ReservationResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetPendingReservationsQuery : IRequest<List<GetPendingReservationQueryResult>>
    {
    }
}
