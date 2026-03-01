using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.CommentQueires;
using UdemyCarbook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarbook.Application.Interfaces.CommentInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentListByBlogIdHandler : IRequestHandler<GetCommentListByBlogIdQuery, List<GetCommentListByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
        public GetCommentListByBlogIdHandler(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetCommentListByBlogIdQueryResult>> Handle(GetCommentListByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCommentsByBlogIdAsync(request.Id);
            return _mapper.Map<List<GetCommentListByBlogIdQueryResult>>(values);
        }
    }
}
