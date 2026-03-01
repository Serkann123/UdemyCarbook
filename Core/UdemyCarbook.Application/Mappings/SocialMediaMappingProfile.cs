using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.SocialMediaCommands;
using UdemyCarbook.Application.Features.Mediator.Results.SocialMediaResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class SocialMediaMappingProfile : Profile
    {
        public SocialMediaMappingProfile()
        {
            CreateMap<SocialMedia, GetSocialMediaQueryResult>();
            CreateMap<SocialMedia, GetSocialMediaByIdQueyResult>();
            CreateMap<CreateSocialMediaCommand, SocialMedia>();
            CreateMap<UpdateSocialMediaCommand, SocialMedia>()
                .ForMember(dest => dest.SocialMediaId, opt => opt.Ignore());
        }
    }
}
