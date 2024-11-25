using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.CarPirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.CarPirincingResults;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarPirincingHandler
{
    public class GetCarPİrincingWithCarQueryHandler:IRequestHandler<GetCarPirincingWithCarQuery,List<GetCarPirincingWithCarQueryResult>>
    {
        private readonly ICarPirincingRepository _pirincing;

        public GetCarPİrincingWithCarQueryHandler(ICarPirincingRepository pirincing)
        {
            _pirincing = pirincing;
        }

        public async Task<List<GetCarPirincingWithCarQueryResult>> Handle(GetCarPirincingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _pirincing.GetCarPirincingWihCars();
            return values.Select(x => new GetCarPirincingWithCarQueryResult
            {
                Amount=x.Ammount,
                Brand=x.Car.Brand.Name,
                CoverImageUrl=x.Car.CoverImageUrl,
                Model=x.Car.Model,
                CarPirincingId=x.CarPricingId

            }).ToList();
        }
    }
}
