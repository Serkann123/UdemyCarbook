using AutoMapper;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Commands.PirincingCommands;
using UdemyCarbook.Application.Features.Mediator.Results.PiricingResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class PricingMappingProfile : Profile
    {
        public PricingMappingProfile()
        {
            CreateMap<Piricing, GetPiricingQueryResult>();
            CreateMap<Piricing, GetPirincingByIdQueryResult>();
            CreateMap<CreatePirincingCommand, Piricing>();
            CreateMap<UpdatePirincingCommand, Piricing>()
                .ForMember(dest => dest.PricingId, opt => opt.Ignore());
        }
    }
}
