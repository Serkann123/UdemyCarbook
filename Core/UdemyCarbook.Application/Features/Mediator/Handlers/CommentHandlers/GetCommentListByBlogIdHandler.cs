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
    public class GetCommentListByBlogIdHandler : IRequestHandler<GetCommentListByBlogIdQuery, List<GetCommentListByBlogIdQueryResult>>
    {
        private readonly ICommentRepository _repository;

        public GetCommentListByBlogIdHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentListByBlogIdQueryResult>> Handle(GetCommentListByBlogIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCommentsByBlogIdAsync(request.Id);
            return values.Select(x => new GetCommentListByBlogIdQueryResult
            {
                CommentId = x.CommentId,
                Name = x.Name,
                CreateDate = x.CreateDate,
                Description = x.Description,
                BlogId = x.BlogId,
                Email = x.Email
            }).ToList();
        }
    }
}
