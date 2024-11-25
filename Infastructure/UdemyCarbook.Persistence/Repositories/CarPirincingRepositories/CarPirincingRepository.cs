using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.CarPirincingRepositories
{
    public class CarPirincingRepository: ICarPirincingRepository
    {
        private readonly CarbookContext _context;

        public CarPirincingRepository(CarbookContext context)
        {
            _context=context;
        }

        public List<CarPricing> GetCarPirincingWihCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Piricing).Where(x=>x.PiricingId==2).ToList();
            return values;
        }

    }
}
