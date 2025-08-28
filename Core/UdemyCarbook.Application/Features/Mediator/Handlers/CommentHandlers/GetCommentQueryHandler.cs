using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.CommentQueires;
using UdemyCarbook.Application.Features.Mediator.Results.CommentResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class GetCommentQueryHandler:IRequestHandler<GetCommentQuery,List<GetCommentQueryResult>>
    {
        private readonly IRepository<Comment> _repository;

        public GetCommentQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCommentQueryResult>> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();

            return values.Select(x => new GetCommentQueryResult
            {
                CommentId = x.CommentId,
                Name = x.Name,
                CreateDate = x.CreateDate,
                Description = x.Description,
                BlogId = x.BlogId,
                Email = x.Email,
            }).ToList();
        }
    }
}
