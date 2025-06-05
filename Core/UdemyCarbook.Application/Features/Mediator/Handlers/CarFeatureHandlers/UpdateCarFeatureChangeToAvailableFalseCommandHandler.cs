using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using UdemyCarbook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureChangeToAvailableFalseCommandHandler : IRequestHandler<UpdateCarFeatureChangeToAvailableFalseCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureChangeToAvailableFalseCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureChangeToAvailableFalseCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeaturesAvailableToFalse(request.Id);
        }
    }
}
