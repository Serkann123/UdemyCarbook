using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.CQRS.Results.CarResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCarQueryResult
            {
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
