using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Queries.CarQueries;
using UdemyCarbook.Application.Features.CQRS.Results.CarResults;
using UdemyCarbook.Application.Interfaces.CarInterfaces;

namespace UdemyCarbook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarMainCarFeatureQueryHandler
    {
        private readonly ICarRepository _repository;
        private readonly IMapper _mapper;

        public GetCarMainCarFeatureQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCarMainCarFeatureResult> Handle(GetCarMainCarFeatureQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetCarMainCarFeatureAsync(request.Id);
            return _mapper.Map<GetCarMainCarFeatureResult>(value);
        }
    }
}
