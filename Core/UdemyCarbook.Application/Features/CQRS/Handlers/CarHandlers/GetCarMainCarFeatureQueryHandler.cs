using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarbook.Application.Features.CQRS.Results.CarResults;
using UdemyCarbook.Application.Interfaces.CarInterfaces;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarMainCarFeatureQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarMainCarFeatureQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarMainCarFeatureResult> Handle(GetCarMainCarFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarMainCarFeatureAsync(request.Id);
            return new GetCarMainCarFeatureResult
            {
                BigImageUrl = values.BigImageUrl,
                BrandId = values.BrandId,
                BrandName = values.Brand.Name,
                CarId = values.CarId,
                CoverImageUrl = values.CoverImageUrl,
                Fuel = values.Fuel,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                Seat = values.Seat,
                Transmission = values.Transmission,
            };
        }
    }
}
