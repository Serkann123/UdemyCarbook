using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.FeatureResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.FeatureQueires
{
    public class GetFeatureQuery:IRequest<List<GetFeatureQueryResult>>
    {
       
    }
}
