using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarbook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarbook.Application.Interfaces.TagCloudInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByBlogIdQueryHandler : IRequestHandler<GetTagCloudByBlogIdQuery, List<GetTagCloudByBlogIdQueryResult>>
    {
        private readonly ITagCloudRepository _repository;
        private readonly IMapper _mapper;

        public GetTagCloudByBlogIdQueryHandler(ITagCloudRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetTagCloudByBlogIdQueryResult>> Handle(GetTagCloudByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetTagCloudByBlogIdAsync(request.Id);
            return _mapper.Map<List<GetTagCloudByBlogIdQueryResult>>(values);
        }
    }
}
