using UdemyCarbook.Dto.RentACarFilterDtos;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.Application.Services
{
    public interface IRentACarApiService
    {
        Task<List<FilterRentACarDto>> GetAvailableAsync(RentSearchDto query);
    }
}
