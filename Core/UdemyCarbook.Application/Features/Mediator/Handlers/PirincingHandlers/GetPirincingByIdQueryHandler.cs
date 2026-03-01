using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.PirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.PiricingResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.PirincingHandlers
{
    public class GetPirincingByIDQueryHandler : IRequestHandler<GetPirincingByIdQuery, GetPirincingByIdQueryResult>
    {
        private readonly IRepository<Piricing> _repository;
        private readonly IMapper _mapper;

        public GetPirincingByIDQueryHandler(IRepository<Piricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetPirincingByIdQueryResult> Handle(GetPirincingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetPirincingByIdQueryResult>(value);
        }
    }
}