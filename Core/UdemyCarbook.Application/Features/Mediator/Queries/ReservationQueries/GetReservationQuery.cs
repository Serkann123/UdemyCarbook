using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.ReservationResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.ReservationQueries
{
    public class GetReservationQuery:IRequest<List<GetReservationQueryResult>>
    {
    }
}
