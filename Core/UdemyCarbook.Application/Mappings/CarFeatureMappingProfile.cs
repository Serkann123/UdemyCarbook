using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.CarFeaturesCommands;
using UdemyCarbook.Application.Features.Mediator.Results.CarFeatureResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class CarFeatureMappingProfile : Profile
    {
        public CarFeatureMappingProfile()
        {
            CreateMap<CreateCarFeatureByCarCommand, CarFeature>()
                .ForMember(d => d.Available, o => o.MapFrom(_ => false));

            CreateMap<CarFeature, GetCarFeatureByCarIdQueryResult>()
                .ForMember(d => d.FeatureName, o => o.MapFrom(s => s.Feature.Name));
        }
    }
}
