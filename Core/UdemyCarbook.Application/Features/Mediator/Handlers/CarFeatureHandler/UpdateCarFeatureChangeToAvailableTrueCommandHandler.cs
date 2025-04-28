using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using UdemyCarbook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarFeatureHandler
{
    public class UpdateCarFeatureChangeToAvailableTrueCommandHandler : IRequestHandler<UpdateCarFeatureChangeToAvailableTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureChangeToAvailableTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureChangeToAvailableTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeaturesAvailableToTrue(request.Id);
        }
    }
}
