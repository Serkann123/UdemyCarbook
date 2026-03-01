using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.ServiceQueries;
using UdemyCarbook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IRepository<Service> _repository;
        private readonly IMapper _mapper;
        public GetServiceQueryHandler(IRepository<Service> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetServiceQueryResult>>(values);
        }
    }
}
