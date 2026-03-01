using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.CarFeatureQueries;
using UdemyCarbook.Application.Features.Mediator.Results.CarFeatureResults;
using UdemyCarbook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;
        private readonly IMapper _mapper;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarFeatureByCarIdAsync(request.Id);
            return _mapper.Map<List<GetCarFeatureByCarIdQueryResult>>(values);
        }
    }
}
