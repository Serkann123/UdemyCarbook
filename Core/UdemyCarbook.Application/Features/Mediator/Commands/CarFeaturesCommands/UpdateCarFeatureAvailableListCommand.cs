using MediatR;
using UdemyCarbook.Dto.CarFeatures;

namespace UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands
{
    public class UpdateCarFeatureAvailableListCommand : IRequest
    {
        public List<UpdateCarFeatureAvailableChangeDto> Data { get; set; }

        public UpdateCarFeatureAvailableListCommand(List<UpdateCarFeatureAvailableChangeDto> data)
        {
            Data = data;
        }
    }
}
