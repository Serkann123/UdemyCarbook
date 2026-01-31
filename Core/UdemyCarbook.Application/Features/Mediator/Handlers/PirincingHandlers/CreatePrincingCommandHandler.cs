using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.PirincingCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.PirincingHandlers
{
    public class CreatePrincingCommandHandler : IRequestHandler<CreatePirincingCommand>
    {
        private readonly IRepository<Piricing> _repository;
        public CreatePrincingCommandHandler(IRepository<Piricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreatePirincingCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Piricing
            {
                Name = request.Name
            });
        }
    }
}
