using MediatR;
using UdemyCarbook.Dto.RentACarFilterDtos;

namespace UdemyCarbook.Application.Features.Mediator.Queries.RentACarQueiries
{
    public class GetAvailableRentACarsQuery:IRequest<List<FilterRentACarDto>>
    {
        public int LocationId { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime DropOff { get; set; }
    }
}
