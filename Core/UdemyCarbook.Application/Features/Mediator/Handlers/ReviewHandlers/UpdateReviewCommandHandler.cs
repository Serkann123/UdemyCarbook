using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IRepository<Review> _repository;
        private readonly IMapper _mapper;

        public UpdateReviewCommandHandler(IRepository<Review> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.ReviewId);
            _mapper.Map(request, value);
            await _repository.UpdateAsync(value);
        }
    }
}