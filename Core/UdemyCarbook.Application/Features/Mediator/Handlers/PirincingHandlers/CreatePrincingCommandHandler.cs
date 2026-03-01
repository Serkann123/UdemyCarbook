using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.PirincingCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.PirincingHandlers
{
    public class CreatePrincingCommandHandler : IRequestHandler<CreatePirincingCommand>
    {
        private readonly IRepository<Piricing> _repository;
        private readonly IMapper _mapper;

        public CreatePrincingCommandHandler(IRepository<Piricing> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task Handle(CreatePirincingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(_mapper.Map<Piricing>(request));
        }
    }
}