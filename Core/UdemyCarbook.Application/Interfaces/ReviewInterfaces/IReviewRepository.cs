using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
      Task<List<Review>> GetReviewByCarIdAsync(int carId);
    }
}
