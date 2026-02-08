using UdemyCarbook.Application.Interfaces.RentACarInterfaces;
using UdemyCarbook.Dto.RentACarFilterDtos;
using UdemyCarbook.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace UdemyCarbook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarAvailabilityRepository : IRentACarAvailabilityRepository
    {
        private readonly CarbookContext _context;

        public RentACarAvailabilityRepository(CarbookContext carbookContext)
        {
            _context = carbookContext;
        }

        public async Task<List<FilterRentACarDto>> GetAvailableAsync(int locationId, DateTime pickup, DateTime dropOff)
        {
            var pickupDate = pickup.Date;
            var pickupTime = pickup.TimeOfDay;
            var dropOffDate = dropOff.Date;
            var dropOffTime = dropOff.TimeOfDay;

            var query = _context.RendACars
            .Where(rc => rc.LocationId == locationId && rc.Available)
            .Where(rc => !_context.RendACarProcesses.Any(p =>
                p.CarId == rc.CarId &&

                (p.PickUpDate < dropOffDate ||
                (p.PickUpDate == dropOffDate && p.PickUpTime < dropOffTime)) &&

                (p.DropOffDate > pickupDate ||
                (p.DropOffDate == pickupDate && p.DropOffTime > pickupTime))
            ))
            .Select(x => new FilterRentACarDto
            {
                CarId = x.CarId,
                Brand = x.Car.Brand.Name,
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl,
                Amount = x.Car.CarPricings.Select(p => p.Ammount).FirstOrDefault(),
                Transmission = x.Car.Transmission,
                Fuel = x.Car.Fuel,
                Seat = x.Car.Seat
            });

            return await query.ToListAsync();
        }
    }
}