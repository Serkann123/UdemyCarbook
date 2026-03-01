using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Commands.BannerCommands;
using UdemyCarbook.Application.Features.CQRS.Results.BannerResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class BannerMappingProfile : Profile
    {
        public BannerMappingProfile()
        {
            CreateMap<Banner, GetBannerQueryResult>();
            CreateMap<Banner, GetBannerByIdQueryResult>();
            CreateMap<CreateBannerCommand, Banner>();
            CreateMap<UpdateBannerCommand, Banner>()
                .ForMember(dest => dest.BannerId, opt => opt.Ignore());
        }
    }
}
