using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.CommentQueires;
using UdemyCarbook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarbook.Application.Interfaces.CommentInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCountCommentBlogQueryHandler : IRequestHandler<GetCountCommentBlogQuery, GetCountCommentBlogQueryResult>
    {
        private readonly ICommentRepository _repository;

        public GetCountCommentBlogQueryHandler(ICommentRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetCountCommentBlogQueryResult> Handle(GetCountCommentBlogQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCountCommentBlog(request.Id);
            return new GetCountCommentBlogQueryResult
            {
                CommentBlogCount = value
            };
        }
    }
}