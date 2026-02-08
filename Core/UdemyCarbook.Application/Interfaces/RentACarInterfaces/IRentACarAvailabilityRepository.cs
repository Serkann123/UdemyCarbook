using UdemyCarbook.Dto.RentACarFilterDtos;

namespace UdemyCarbook.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarAvailabilityRepository
    {
       Task<List<FilterRentACarDto>> GetAvailableAsync(int locationId, DateTime pickup, DateTime dropOff);
    }
}
