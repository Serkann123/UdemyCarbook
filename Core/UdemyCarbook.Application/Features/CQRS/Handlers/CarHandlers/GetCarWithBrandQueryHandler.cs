using UdemyCarbook.Application.Features.CQRS.Results.CarResults;
using UdemyCarbook.Application.Interfaces.CarInterfaces;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var values = await _repository.GetCarsListWithBrandAsync();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName = x.Brand.Name,
                CarId = x.CarId,
                BigImageUrl = x.BigImageUrl,
                Fuel = x.Fuel,
                CoverImageUrl = x.CoverImageUrl,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                BrandId = x.BrandId,
            }).ToList();
        }
    }
}
