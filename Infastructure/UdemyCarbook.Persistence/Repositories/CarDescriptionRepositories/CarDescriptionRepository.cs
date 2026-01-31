using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly CarbookContext _context;

        public CarDescriptionRepository(CarbookContext context)
        {
            _context = context;
        }

        public async Task<CarDescription?> GetCarDescriptionAsync(int CarId)
        {
            return await _context.CarDescriptions.FirstOrDefaultAsync(x => x.CarId == CarId);
        }
    }
}
