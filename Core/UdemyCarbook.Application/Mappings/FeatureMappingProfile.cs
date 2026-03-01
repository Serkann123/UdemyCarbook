using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarbook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class FeatureMappingProfile : Profile
    {
        public FeatureMappingProfile()
        {
            CreateMap<Feature, GetFeatureQueryResult>();
            CreateMap<Feature, GetFeatureByIdQueryResult>();
            CreateMap<CreateFeatureCommand, Feature>();
            CreateMap<UpdateFeatureCommand, Feature>()
                .ForMember(d => d.FeatureId, o => o.Ignore());
        }
    }
}
