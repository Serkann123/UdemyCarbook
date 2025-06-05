using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.RentACarResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.RentACarQueiries
{
    public class GetRentACarQuery:IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationId { get; set; }
        public bool Available { get; set; }
        public string PricingName { get; set; } // örn: "Haftalık", "Aylık", "Günlük"

    }
}
