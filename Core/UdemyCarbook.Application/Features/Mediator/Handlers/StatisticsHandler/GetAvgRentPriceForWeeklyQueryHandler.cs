using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarbook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarbook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.StatisticsHandler
{
    public class GetAvgRentPriceForWeeklyQueryHandler : IRequestHandler<GetAvgRentPriceForWeeklyQuery, GetAvgRentPriceForWeeklyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForWeeklyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForWeeklyQueryResult> Handle(GetAvgRentPriceForWeeklyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForWeekly();
            return new GetAvgRentPriceForWeeklyQueryResult
            {
                AvgRentPriceForWeekly = value
            };
        }
    }
}