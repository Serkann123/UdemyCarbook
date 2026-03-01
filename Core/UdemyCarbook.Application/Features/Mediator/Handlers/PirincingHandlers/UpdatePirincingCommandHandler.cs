using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.PirincingCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.PirincingHandlers
{
    public class UpdatePirincingCommandHandler : IRequestHandler<UpdatePirincingCommand>
    {
        private readonly IRepository<Piricing> _repository;
        private readonly IMapper _mapper;

        public UpdatePirincingCommandHandler(IRepository<Piricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePirincingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.PricingId);
            _mapper.Map(request, values);
            await _repository.UpdateAsync(values);
        }
    }
}