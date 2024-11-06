using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.FeatureAddressResults;
using UdemyCarbook.Application.Features.Mediator.Results.FooterAddressResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.FooterAddressQuery
{
    public class GetFooterAddressByIdQuery:IRequest<GetFooterAddressByIdQueryResult>
    {
        public int Id { get; set; }
        public GetFooterAddressByIdQuery(int id)
        {
            Id = id;
        }
    }
}
