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

        //public List<CarPrincingViewModel> GetCarPricingWithTimePeriod()
        //{
        //    using (var command = _context.Database.GetDbConnection().CreateCommand())
        //    {
        //        command.CommandText = "GetCarPricingWithTimePeriodProc";
        //        command.CommandType = System.Data.CommandType.StoredProcedure;

        //        _context.Database.OpenConnection();

        //        var result = new List<CarPrincingViewModel>();
        //        using (var reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                result.Add(new CarPrincingViewModel
        //                {
        //                    Model = reader.GetString(0),
        //                    ModelName=reader.GetString(1),
        //                    BrandName=reader.GetString(2),
        //                    CoverImageUrl=reader.GetString(3),
        //                    DailyAmount = reader.IsDBNull(1) ? 0 : reader.GetDecimal(4),
        //                    WeeklyAmount = reader.IsDBNull(2) ? 0 : reader.GetDecimal(5),
        //                    MonthlyAmount = reader.IsDBNull(3) ? 0 : reader.GetDecimal(6),
        //                });
        //            }
        //        }
        //        return result;
        //    }
        //}

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
                    CoverImgUrl = c.CoverImageUrl
                } into g
                select new CarPrincingViewModel
                {
                    ModelName = g.Key.AracModeli,
                    Model = g.Key.Model,
                    BrandName = g.Key.Brand,
                    CoverImageUrl = g.Key.CoverImgUrl,
                    DailyAmount = g.Where(x => x.cp.PiricingId == 1).Sum(x => (decimal?)x.cp.Ammount) ?? 0,
                    WeeklyAmount = g.Where(x => x.cp.PiricingId == 2).Sum(x => (decimal?)x.cp.Ammount) ?? 0,
                    MonthlyAmount = g.Where(x => x.cp.PiricingId == 3).Sum(x => (decimal?)x.cp.Ammount) ?? 0
                };

            return result.ToList();
        }

    }
}
