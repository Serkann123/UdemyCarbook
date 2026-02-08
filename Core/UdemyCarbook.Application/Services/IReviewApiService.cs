using UdemyCarbook.Dto.ReviewDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IReviewApiService
    {
        Task<List<ResultReviewByCarIdDto>> GetByCarIdAsync(int carId);
    }
}
