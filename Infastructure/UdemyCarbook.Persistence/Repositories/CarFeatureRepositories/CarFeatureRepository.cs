using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task ChangeCarFeaturesAvailableToFalseAsync(int id)
        {
            var values = await _context.CarFeatures.FirstOrDefaultAsync(x => x.CarFeatureId == id);
            values.Available = false;
            _context.SaveChangesAsync();
        }

        public async Task ChangeCarFeaturesAvailableToTrueAsync(int id)
        {
            var values = await _context.CarFeatures.FirstOrDefaultAsync(x => x.CarFeatureId == id);
            values.Available = true;
            _context.SaveChangesAsync();
        }

        public async Task<List<CarFeature>> GetCarFeatureByCarIdAsync(int carId)
        {
            return await _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarId == carId).ToListAsync();
        }
    }
}
