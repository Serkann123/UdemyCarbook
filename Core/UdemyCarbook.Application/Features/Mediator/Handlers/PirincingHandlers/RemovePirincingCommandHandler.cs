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
    public class RemovePirincingCommandHandler : IRequestHandler<RemovePirincingCommand>
    {
        private readonly IRepository<Piricing> _repository;
        public RemovePirincingCommandHandler(IRepository<Piricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemovePirincingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAync(values);
        }
    }
}
