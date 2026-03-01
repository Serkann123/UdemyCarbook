using AutoMapper;
using UdemyCarbook.Application.Enums;
using UdemyCarbook.Application.Features.Mediator.Commands.AppUserCommands;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class AppUserMappingProfile : Profile
    {
        public AppUserMappingProfile()
        {
            CreateMap<CreateAppUserCommand, AppUser>()
                .ForMember(x => x.AppRoleId, opt => opt.MapFrom(y => (int)RoleType.Member));
        }
    }
}
