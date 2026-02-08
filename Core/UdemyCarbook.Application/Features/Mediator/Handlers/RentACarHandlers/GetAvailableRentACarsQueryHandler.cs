using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.RentACarQueiries;
using UdemyCarbook.Application.Interfaces.RentACarInterfaces;
using UdemyCarbook.Dto.RentACarFilterDtos;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetAvailableRentACarsQueryHandler : IRequestHandler<GetAvailableRentACarsQuery, List<FilterRentACarDto>>
    {
        private readonly IRentACarAvailabilityRepository _availabilityRepository;

        public GetAvailableRentACarsQueryHandler(IRentACarAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        public async Task<List<FilterRentACarDto>> Handle(GetAvailableRentACarsQuery request, CancellationToken cancellationToken)
        {
            // Basit validation: ters tarih gelirse boş dön
            if (request.DropOff <= request.PickUp || request.LocationId <= 0)
                return new List<FilterRentACarDto>();

            return await _availabilityRepository.GetAvailableAsync(

                request.LocationId,
                request.PickUp,
                request.DropOff
            );
        }
    }
}
