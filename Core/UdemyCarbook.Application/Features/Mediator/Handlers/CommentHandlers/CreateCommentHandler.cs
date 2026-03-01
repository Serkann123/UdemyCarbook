using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommannd>
    {
        private readonly IRepository<Comment> _repository;
        private readonly IMapper _mapper;

        public CreateCommentHandler(IRepository<Comment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCommentCommannd request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Comment>(request));
        }
    }
}
