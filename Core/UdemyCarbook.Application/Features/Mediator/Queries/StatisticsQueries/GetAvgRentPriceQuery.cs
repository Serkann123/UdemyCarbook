using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.StatisticsResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.StatisticsQueries
{
    public class GetAvgRentPriceQuery:IRequest<GetAvgRentPriceQueryResult>
    {
        public string PricingName { get; set; }

        public GetAvgRentPriceQuery(string pricingName)
        {
            PricingName = pricingName;
        }
    }
}
