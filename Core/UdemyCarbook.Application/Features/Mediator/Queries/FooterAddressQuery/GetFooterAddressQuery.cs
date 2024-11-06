using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.FeatureAddressResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.FooterAddressQuery
{
    public class GetFooterAddressQuery:IRequest<List<GetFooterAddressQueryResult>>
    {
    }
}
