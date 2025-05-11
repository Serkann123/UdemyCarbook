using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<Review> GetReviewByCarId(int carId)
        {
           var values=_carbookContext.Reviews.Where(x=>x.CarId == carId).ToList();
            return values;
        }
    }
}
