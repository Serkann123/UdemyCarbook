using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.PiricingResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.PirincingQueries
{
    public class GetPirincingQuery:IRequest<List<GetPiricingQueryResult>>
    {
    }
}
