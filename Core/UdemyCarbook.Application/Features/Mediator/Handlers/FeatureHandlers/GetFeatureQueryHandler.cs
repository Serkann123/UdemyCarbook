using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.FeatureQueires;
using UdemyCarbook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureQueryHandler :IRequestHandler<GetFeatureQuery,List<GetFeatureQueryResult>>
    {
        private readonly IRepository<Feature> _repository;
        private readonly IMapper _mapper;
        public GetFeatureQueryHandler(IRepository<Feature> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetFeatureQueryResult>>(values);
        }
    }
}