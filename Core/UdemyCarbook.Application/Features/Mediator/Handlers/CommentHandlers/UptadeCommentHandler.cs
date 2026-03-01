using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UptadeCommentHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;
        public UptadeCommentHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.CommentId);
            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);
        }
    }
}
