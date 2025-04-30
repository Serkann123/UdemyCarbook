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

        public void ChangeCarFeaturesAvailableToFalse(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            values.Available = false;
            _context.SaveChangesAsync();
        }

        public void ChangeCarFeaturesAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureId == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChangesAsync();
        }

        public List<CarFeature> GetCarFeatureByCarId(int carId)
        {
            var values = _context.CarFeatures.Include(y => y.Feature).Where(x => x.CarId == carId).ToList();
            return values;
        }
    }
}

