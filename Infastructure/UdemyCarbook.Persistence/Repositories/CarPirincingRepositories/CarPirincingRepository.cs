using Microsoft.EntityFrameworkCore;
using System;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;
using UdemyCarbook.Application.ViewsModel;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.CarPirincingRepositories
{
    public class CarPirincingRepository : ICarPirincingRepository
    {
        private readonly CarbookContext _context;

        public CarPirincingRepository(CarbookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPirincingWihCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Piricing).ToList();
            return values;
        }
        public List<CarPrincingViewModel> GetCarPricingWithTimePeriod()
        {
            var result =
                from cp in _context.CarPricings
                join c in _context.Cars on cp.CarId equals c.CarId
                join b in _context.Brands on c.BrandId equals b.BrandId
                group new { cp, c, b } by new
                {
                    AracModeli = b.Name + " " + c.Model,
                    c.Model,
                    Brand = b.Name,
                    CoverImgUrl = c.CoverImageUrl,
                    c.CarId,
                } into g
                select new CarPrincingViewModel
                {
                    CarId = g.Key.CarId,
                    ModelName = g.Key.AracModeli,
                    Model = g.Key.Model,
                    BrandName = g.Key.Brand,
                    CoverImageUrl = g.Key.CoverImgUrl,
                    DailyAmount = g.Where(x => x.cp.Piricing.Name=="Günlük").Sum(x => (decimal?)x.cp.Ammount) ?? 0,
                    WeeklyAmount = g.Where(x => x.cp.Piricing.Name=="Haftalık").Sum(x => (decimal?)x.cp.Ammount) ?? 0,
                    MonthlyAmount = g.Where(x => x.cp.Piricing.Name=="Aylık").Sum(x => (decimal?)x.cp.Ammount) ?? 0
                };

            return result.ToList();
        }
    }
}
