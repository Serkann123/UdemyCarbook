using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarbook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarbook.Application.Interfaces.BlogInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetLast3BlogsWithAuthorsQueryHandler : IRequestHandler<GetLast3BlogsWithAuthorsQuery, List<GetLast3BlogsWithAuthorsQueryResult>>
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;
        public GetLast3BlogsWithAuthorsQueryHandler(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetLast3BlogsWithAuthorsQueryResult>> Handle(GetLast3BlogsWithAuthorsQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetLast3BlogsWithAuthorsAsync();
            return _mapper.Map<List<GetLast3BlogsWithAuthorsQueryResult>>(values);
        }
    }
}