using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.PirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.PiricingResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.PirincingHandlers
{
    public class GetPirincingQueryHandler : IRequestHandler<GetPirincingQuery, List<GetPiricingQueryResult>>
    {
        private readonly IRepository<Piricing> _repository;
        private readonly IMapper _mapper;

        public GetPirincingQueryHandler(IRepository<Piricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetPiricingQueryResult>> Handle(GetPirincingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetPiricingQueryResult>>(values);
        }
    }
}