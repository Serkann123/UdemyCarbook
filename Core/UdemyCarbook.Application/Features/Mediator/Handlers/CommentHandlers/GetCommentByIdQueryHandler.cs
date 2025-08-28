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
    public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdQueryResult>
    {
        private readonly IRepository<Comment> _repository;
        public GetCommentByIdQueryHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }
        public async Task<GetCommentByIdQueryResult> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
        {
            var values =await _repository.GetByIdAsync(request.Id);

            return new GetCommentByIdQueryResult
            {
                CommentId = values.CommentId,
                Name = values.Name,
                CreateDate = values.CreateDate,
                Description = values.Description,
                BlogId = values.BlogId,
                Email = values.Email,
            };
        }
    }
}
