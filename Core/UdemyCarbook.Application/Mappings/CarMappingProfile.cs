using AutoMapper;
using UdemyCarbook.Application.Features.CQRS.Commands.CarCommands;
using UdemyCarbook.Application.Features.CQRS.Results.CarResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class CarMappingProfile : Profile
    {
        public CarMappingProfile()
        {
            CreateMap<Car, GetCarQueryResult>();
            CreateMap<Car, GetCarByIdQueryResult>();
            CreateMap<Car, GetCarMainCarFeatureResult>();
            CreateMap<Car, GetCarWithBrandQueryResult>();
            CreateMap<CreateCarCommand, Car>();
            CreateMap<UpdateCarCommand, Car>()
                .ForMember(dest => dest.CarId, opt => opt.Ignore());
        }
    }
}
