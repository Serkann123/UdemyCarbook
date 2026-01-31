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
    public class GetCarBrandAndModeByRentPriceDailyMaxQueryHandler : IRequestHandler<GetCarBrandAndModeByRentPriceDailyMaxQuery, GetCarBrandAndModeByRentPriceDailyMaxQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetCarBrandAndModeByRentPriceDailyMaxQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarBrandAndModeByRentPriceDailyMaxQueryResult> Handle(GetCarBrandAndModeByRentPriceDailyMaxQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarBrandAndModeByRentPriceDailyMaxAsync();
            return new GetCarBrandAndModeByRentPriceDailyMaxQueryResult
            {
                CarBrandAndModeByRentPriceDailyMax = value
            };
        }
    }
}