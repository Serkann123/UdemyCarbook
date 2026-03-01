using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.LocationCommands;
using UdemyCarbook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class LocationMappingProfile : Profile
    {
        public LocationMappingProfile()
        {
            CreateMap<Location, GetLocationQueryResult>();
            CreateMap<Location, GetLocationByIdQueryResult>();
            CreateMap<CreateLocationCommand, Location>();
            CreateMap<UpdateLocationCommand, Location>()
                .ForMember(dest => dest.LocationId, opt => opt.Ignore());
        }
    }
}
