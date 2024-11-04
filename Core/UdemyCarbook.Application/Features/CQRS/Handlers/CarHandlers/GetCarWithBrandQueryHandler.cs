using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.CQRS.Results.CarResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Application.Interfaces.CarInterfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarWithBrandQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetCarWithBrandQueryResult> Handle()
        {
            var values = _repository.GetCarsListWithBrand();
            return values.Select(x => new GetCarWithBrandQueryResult
            {
                BrandName=x.Brand.Name,
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
