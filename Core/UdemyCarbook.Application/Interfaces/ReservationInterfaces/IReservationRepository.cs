using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.ReservationInterfaces
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetPendingAsync();
    }
}
