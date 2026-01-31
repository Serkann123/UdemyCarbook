using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class RemoveCarFeatureByCarCommandHandler : IRequestHandler<RemoveCarFeatureByCarCommand>
    {
        private readonly IRepository<CarFeature> _repository;

        public RemoveCarFeatureByCarCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            await _repository.RemoveAync(values);
        }
    }
}
