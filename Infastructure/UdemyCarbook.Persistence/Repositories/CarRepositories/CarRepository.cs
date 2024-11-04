using Microsoft.EntityFrameworkCore;
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
        private readonly CarbookContext _carbookContext;
        public CarRepository(CarbookContext carbookContext)
        {
            _carbookContext = carbookContext;
        }

        public List<Car> GetCarsListWithBrand()
        {
            var values = _carbookContext.Cars.Include(x => x.Brand).ToList();
            return values;
        }
    }
}
