using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.CarPirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.CarPirincingResults;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarPirincingHandlers
{
    public class GetCarPİrincingWithCarQueryHandler : IRequestHandler<GetCarPirincingWithCarQuery, List<GetCarPirincingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _pirincing;
        private readonly IMapper _mapper;

        public GetCarPİrincingWithCarQueryHandler(ICarPricingRepository pirincing,IMapper mapper)
        {
            _pirincing = pirincing;
            _mapper = mapper;
        }

        public async Task<List<GetCarPirincingWithCarQueryResult>> Handle(GetCarPirincingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _pirincing.GetCarPirincingWihCarsAsync();
            return _mapper.Map<List<GetCarPirincingWithCarQueryResult>>(values);
        }
    }
}
