using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarbook.Application.Features.CQRS.Results.CarResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarId=values.CarId,
                BigImageUrl = values.BigImageUrl,
                Fuel = values.Fuel,
                CoverImageUrl = values.CoverImageUrl,
                Transmission = values.Transmission,
                Seat = values.Seat,
                Km = values.Km,
                Luggage = values.Luggage,
                Model = values.Model,
                BrandId = values.BrandId,
            };
        }
    }
}
