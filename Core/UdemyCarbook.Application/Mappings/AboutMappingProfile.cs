using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Commands.AboutCommands;
using UdemyCarbook.Application.Features.CQRS.Results.AboutResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class AboutMappingProfile : Profile
    {
        public AboutMappingProfile()
        {
            CreateMap<About, GetAboutQueryResult>();
            CreateMap<About, GetAboutByIdQueryResult>();
            CreateMap<CreateAboutCommand, About>();
            CreateMap<UpdateAboutCommand, About>()
                .ForMember(dest => dest.AboutId, opt => opt.Ignore());
        }
    }
}
