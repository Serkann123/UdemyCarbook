using UdemyCarbook.Dto.StatisticsDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IStatisticsApiService
    {
        Task<GetDashboardDto> GetDashboardAsync();
    }
}
