using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.CarPirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.CarPirincingResults;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarPirincingHandlers
{
    public class GetCarPrincingWithTimePeriodQueryHandler : IRequestHandler<GetCarPrincingWithTimePeriodQuery, List<GetCarPrincingWithTimePeriodQueryResult>>
    {
        private readonly ICarPricingRepository _repository;
        private readonly IMapper _mapper;

        public GetCarPrincingWithTimePeriodQueryHandler(ICarPricingRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarPrincingWithTimePeriodQueryResult>> Handle(GetCarPrincingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarPricingWithTimePeriodAsync();

            return _mapper.Map<List<GetCarPrincingWithTimePeriodQueryResult>>(values);
        }
    }
}
