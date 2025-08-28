using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class RemoveCommentHandler:IRequestHandler<RemoveCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public RemoveCommentHandler(IRepository<Comment> repository)
        {
            _repository= repository;
        }

        public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAync(values);
        }
    }
}
