using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.StatisticsQueries;
using UdemyCarbook.Application.Features.Mediator.Results.StatisticsResults;
using UdemyCarbook.Application.Interfaces.StatisticsInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceQueryHandler : IRequestHandler<GetAvgRentPriceQuery, GetAvgRentPriceQueryResult>
    {
        private readonly IStatisticsRepository _repository;

        public GetAvgRentPriceQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceQueryResult> Handle(GetAvgRentPriceQuery request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAvgRentPriceByPricingNameAsync(request.PricingName);
            return new GetAvgRentPriceQueryResult
            {
                AvgPrice = result
            };
        }
    }
}