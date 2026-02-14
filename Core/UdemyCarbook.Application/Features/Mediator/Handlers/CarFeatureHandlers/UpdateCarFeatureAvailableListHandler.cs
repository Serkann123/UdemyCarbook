using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using UdemyCarbook.Application.Interfaces.CarFeatureInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class UpdateCarFeatureAvailableListHandler : IRequestHandler<UpdateCarFeatureAvailableListCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureAvailableListHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCarFeatureAvailableListCommand request, CancellationToken cancellationToken)
        {
            foreach (var item in request.Data)
            {
                await _repository.UpdateCarFeatureAvailableAsync(item.CarFeatureId, item.Available);
            }

            await _repository.SaveChangesAsync();
        }
    }
}
