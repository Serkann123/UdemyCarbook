using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Interfaces.RentACarInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarbookContext _context;

        public RentACarRepository(CarbookContext carbookContext)
        {
            _context = carbookContext;
        }

        public async Task<List<RendACar>> GetByFilterAsync(Expression<Func<RendACar, bool>> filter)
        {
            var values = await _context.RendACars.Where(filter).Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Car) .ThenInclude(y => y.CarPricings).ThenInclude(y=>y.Piricing).ToListAsync();
            return values;
        }
    }
}
