using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.CarPirincingResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.CarPirincingQueries
{
    public class GetCarPirincingQuery:IRequest<List<GetCarPirincingQueryResult>>
    {
    }
}
