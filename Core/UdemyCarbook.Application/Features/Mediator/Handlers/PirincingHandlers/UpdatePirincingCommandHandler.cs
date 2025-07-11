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
    public class UpdatePirincingCommandHandler:IRequestHandler<UpdatePirincingCommand>
    {
        private readonly IRepository<Piricing> _repository;
        public UpdatePirincingCommandHandler(IRepository<Piricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePirincingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.PricingId);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
