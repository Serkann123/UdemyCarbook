using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarbook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarbook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    internal class GetCarBrandAndModeByRentPriceDailyMinQueryHandler : IRequestHandler<GetCarBrandAndModeByRentPriceDailyMinQuery, GetCarBrandAndModeByRentPriceDailyMinQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModeByRentPriceDailyMinQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModeByRentPriceDailyMinQueryResult> Handle(GetCarBrandAndModeByRentPriceDailyMinQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarBrandAndModeByRentPriceDailyMin();
            return new GetCarBrandAndModeByRentPriceDailyMinQueryResult
            {
                CarBrandAndModeByRentPriceDailyMin = value
            };
        }
    }
}