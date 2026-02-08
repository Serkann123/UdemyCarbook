using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.ReservationInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly CarbookContext _context;

        public ReservationRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetPendingAsync()
        {
            return await _context.Reservations
                 .Include(x => x.Car).ThenInclude(x => x.Brand)
                 .Include(x => x.PickUpLocation)
                 .Include(x => x.DropOffLocation)
                 .Where(x => x.Status == "Pending")
                 .OrderBy(x => x.PickUpDateTime)
                 .ToListAsync();
        }
    }
}
