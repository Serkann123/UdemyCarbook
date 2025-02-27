using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.CarPirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.CarPirincingResults;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarPirincingHandler
{
    public class GetCarPrincingWithTimePeriodQueryHandler : IRequestHandler<GetCarPrincingWithTimePeriodQuery, List<GetCarPrincingWithTimePeriodQueryResult>>
    {
        private readonly ICarPirincingRepository _repository;

        public GetCarPrincingWithTimePeriodQueryHandler(ICarPirincingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPrincingWithTimePeriodQueryResult>> Handle(GetCarPrincingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithTimePeriod1();
            return values.Select(x => new GetCarPrincingWithTimePeriodQueryResult
            {
                Model=x.Model,
                DailyAmount = x.Amounts[0],
                WeeklyAmount = x.Amounts[1],
                MonthlyAmount = x.Amounts[2]
            }).ToList();
        }
    }
}