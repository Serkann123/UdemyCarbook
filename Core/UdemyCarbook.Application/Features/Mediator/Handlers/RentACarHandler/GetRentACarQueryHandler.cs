using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.RentACarQueiries;
using UdemyCarbook.Application.Features.Mediator.Results.RentACarResults;
using UdemyCarbook.Application.Interfaces.RentACarInterfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.RentACarHandler
{
    public class GetRentACarQueryHandler:IRequestHandler<GetRentACarQuery,List<GetRentACarQueryResult>>
    {
        private readonly IRentACarRepository _rentACarRepository;

        public GetRentACarQueryHandler(IRentACarRepository rentACarRepository)
        {
            _rentACarRepository = rentACarRepository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = await _rentACarRepository.GetByFilterAsync(x => x.LocationId == request.LocationId && x.Available == true);

            var results = values.Select(x => new GetRentACarQueryResult
            {
                CarId = x.CarId,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImageUrl=x.Car.CoverImageUrl,
                Amount = x.Car.CarPricings.FirstOrDefault(y => y.CarId == x.CarId)?.Ammount ?? 0
            }).ToList();

            return results;
        }
    }
}
