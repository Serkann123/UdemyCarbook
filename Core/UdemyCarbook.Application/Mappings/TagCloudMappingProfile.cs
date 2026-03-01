using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.TagCloudCommands;
using UdemyCarbook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class TagCloudMappingProfile : Profile
    {
        public TagCloudMappingProfile()
        {
            CreateMap<TagCloud, GetTagCloudQueryResult>();
            CreateMap<TagCloud, GetTagCloudByIdQueryResult>();
            CreateMap<CreateTagCloudCommand, TagCloud>();
            CreateMap<UpdateTagCloudCommand, TagCloud>()
                .ForMember(dest => dest.TagCloudId, opt => opt.Ignore());
            CreateMap<TagCloud, GetTagCloudByBlogIdQueryResult>();
        }
    }
}
