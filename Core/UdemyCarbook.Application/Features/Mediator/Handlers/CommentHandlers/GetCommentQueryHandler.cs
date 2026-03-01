using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.CommentQueires;
using UdemyCarbook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentQueryHandler:IRequestHandler<GetCommentQuery,List<GetCommentQueryResult>>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;
        public GetCommentQueryHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<GetCommentQueryResult>>(values);
        }
    }
}
