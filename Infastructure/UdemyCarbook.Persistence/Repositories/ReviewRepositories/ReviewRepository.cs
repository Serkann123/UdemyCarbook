using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.ReviewInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarbookContext _carbookContext;

        public ReviewRepository(CarbookContext carbookContext)
        {
            _carbookContext = carbookContext;
        }

        public async Task<List<Review>> GetReviewByCarIdAsync(int carId)
        {
            return await _carbookContext.Reviews.Where(x => x.CarId == carId).ToListAsync();
        }
    }
}
