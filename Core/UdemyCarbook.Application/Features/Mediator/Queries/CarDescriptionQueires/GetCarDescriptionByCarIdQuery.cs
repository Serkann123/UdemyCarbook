using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.CarDescriptionResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.CarDescriptionQueires
{
    public class GetCarDescriptionByCarIdQuery:IRequest<GetCarDescriptionQueryResult>
    {
        public int Id { get; set; }
        public GetCarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
