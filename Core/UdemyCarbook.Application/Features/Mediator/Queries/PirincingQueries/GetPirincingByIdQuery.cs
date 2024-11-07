using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.PiricingResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.PirincingQueries
{
    public class GetPirincingByIdQuery:IRequest<GetPirincingByIdQueryResult>
    {
        public int Id { get; set; }

        public GetPirincingByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
