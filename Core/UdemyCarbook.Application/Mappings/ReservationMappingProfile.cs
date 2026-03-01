using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarbook.Application.Features.Mediator.Results.ReservationResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<Reservation, GetReservationQueryResult>();
            CreateMap<Reservation, GetReservationByIdQueryResult>();
            CreateMap<Reservation, GetPendingReservationQueryResult>()
               .ForMember(d => d.CarName,
                   o => o.MapFrom(s => s.Car.Brand.Name + " " + s.Car.Model));
            CreateMap<CreateReservationCommand, Reservation>()
              .ForMember(d => d.Status, o => o.MapFrom(s => "Pending"));
            CreateMap<UpdateReservationCommand, Reservation>()
                .ForMember(d => d.ReservationId, o => o.Ignore());
        }
    }
}
