using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.CarInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarbookContext _context;
        public CarRepository(CarbookContext carbookContext)
        {
            _context = carbookContext;
        }

        public async Task<int> GetCarCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<Car?> GetCarMainCarFeatureAsync(int id)
        {
            return await _context.Cars.Include(x => x.Brand).FirstOrDefaultAsync(x => x.CarId == id);
        }

        public async Task<List<Car>> GetCarsListWithBrandAsync()
        {
            return await _context.Cars.Include(x => x.Brand).ToListAsync();
        }

        public async Task<List<Car>> GetLast5WithCarsWithBrandAsync()
        {
            return await _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarId).Take(5).ToListAsync();
        }
    }
}
