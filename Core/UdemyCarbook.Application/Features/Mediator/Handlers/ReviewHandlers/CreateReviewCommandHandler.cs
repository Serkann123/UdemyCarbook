using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        private readonly IMapper _mapper;

        public CreateReviewCommandHandler(IRepository<Review> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = _mapper.Map<Review>(request);
            await _repository.CreateAsync(value);
        }
    }
}
