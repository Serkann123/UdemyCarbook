using UdemyCarbook.Dto.ReservationDtos;
using UdemyCarbook.WebUI.Models;

namespace UdemyCarbook.Application.Services
{
    public interface IReservationApiService
    {
        Task<ApiPostResult> CreateAsync(CreateReservationDto dto);
        Task<List<ResultPendingDto>> GetPendingReservationsAsync();

        Task<ApiPostResult> ApproveAsync(int reservationId);
        Task<ApiPostResult> RejectAsync(int reservationId);
    }
}
