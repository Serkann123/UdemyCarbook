using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarbookContext _context;

        public CarFeatureRepository(CarbookContext context)
        {
            _context = context;
        }
  
        public async Task<List<CarFeature>> GetCarFeatureByCarIdAsync(int carId)
        {
            return await _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarId == carId).ToListAsync();
        }

        public async Task UpdateCarFeatureAvailableAsync(int carFeatureId, bool available)
        {
            var value = await _context.CarFeatures.FindAsync(carFeatureId);
            if (value is not null)
            {
                value.Available = available;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
