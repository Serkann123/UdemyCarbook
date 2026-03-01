using MediatR;
using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarbook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.TagClouds.Mediator.Handlers.TagCloudHandlers
{
    internal class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;
        private readonly IMapper _mapper;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetTagCloudByIdQueryResult>(values);
        }
    }
}