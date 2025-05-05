using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int GetCarCount()
        {
            var values = _context.Cars.Count();
            return values;
        }

        public Car GetCarMainCarFeature(int id)
        {
            var values = _context.Cars.Include(x => x.Brand).Where(x => x.CarId == id).FirstOrDefault();
            return values;
        }

        public List<Car> GetCarsListWithBrand()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }

        public List<Car> GetLast5WithCarsWithBrand()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarId).Take(5).ToList();
            return values;
        }
    }
}
