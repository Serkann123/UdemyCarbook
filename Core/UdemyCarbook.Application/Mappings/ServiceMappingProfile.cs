using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.ServiceCommands;
using UdemyCarbook.Application.Features.Mediator.Results.ServiceResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class ServiceMappingProfile : Profile
    {
        public ServiceMappingProfile()
        {
            CreateMap<Service, GetServiceQueryResult>();
            CreateMap<Service, GetServiceByIdQueryResult>();
            CreateMap<CreateServiceCommand, Service>();
            CreateMap<UpdateServiceCommand, Service>()
                .ForMember(dest => dest.ServiceId, opt => opt.Ignore());
        }
    }
}
