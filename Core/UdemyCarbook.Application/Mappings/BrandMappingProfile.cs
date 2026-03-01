using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Commands.BrandCommands;
using UdemyCarbook.Application.Features.CQRS.Results.BrandResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class BrandMappingProfile : Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, GetBrandQueryResult>();
            CreateMap<Brand, GetBrandByIdQueryResult>();
            CreateMap<CreateBrandCommand, Brand>();
            CreateMap<UpdateBrandCommand, Brand>()
                .ForMember(dest => dest.BrandId, opt => opt.Ignore());
        }
    }
}
