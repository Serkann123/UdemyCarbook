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
    public class GetAvgRentPriceForMonthlyQueryHandler : IRequestHandler<GetAvgRentPriceForMonthlyQuery, GetAvgRentPriceForMonthlyQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceForMonthlyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForMonthlyQueryResult> Handle(GetAvgRentPriceForMonthlyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForMonthly();
            return new GetAvgRentPriceForMonthlyQueryResult
            {
                GetAvgRentPriceForMonthly = value
            };
        }
    }
}