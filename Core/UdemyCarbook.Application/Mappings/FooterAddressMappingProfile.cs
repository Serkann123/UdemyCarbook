using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.FooterAddressCommands;
using UdemyCarbook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class FooterAddressMappingProfile : Profile
    {
        public FooterAddressMappingProfile()
        {
            CreateMap<FooterAddress, GetFooterAddressQueryResult>();
            CreateMap<FooterAddress, GetFooterAddressByIdQueryResult>();
            CreateMap<CreateFooterAddressCommand, FooterAddress>();
            CreateMap<UpdateFooterAddressCommand, FooterAddress>()
                .ForMember(dest => dest.FooterAddressId, opt => opt.Ignore());
        }
    }
}
