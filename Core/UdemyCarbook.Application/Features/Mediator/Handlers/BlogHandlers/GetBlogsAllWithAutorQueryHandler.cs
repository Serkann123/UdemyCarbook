using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarbook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarbook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogsAllWithAutorQueryHandler : IRequestHandler<GetBlogsAllWithAutorQuery, List<GetBlogsAllWithAuthorQueryResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        public GetBlogsAllWithAutorQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetBlogsAllWithAuthorQueryResult>> Handle(GetBlogsAllWithAutorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetBlogsAllWithAuthorsAsync();
            return _mapper.Map<List<GetBlogsAllWithAuthorQueryResult>>(values);
        }
    }
}