using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.FeatureResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.FeatureQueires
{
    public class GetFeatureByIdQuery:IRequest<GetFeatureByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFeatureByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
