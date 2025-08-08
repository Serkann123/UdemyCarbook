using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarbookContext _context;

        public StatisticsRepository(CarbookContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var values = _context.Comments.GroupBy(x => x.BlogId)
                .Select(y => new
                {
                    BlogId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z => z.Count).FirstOrDefault();

            var titleName = _context.Blogs.Where(x => x.BlogId == values.BlogId).Select(y => y.Title).FirstOrDefault();
            return titleName;
        }

        public string GetBrandNameByMaxCar()
        {
            var values = _context.Cars.GroupBy(x => x.BrandId)
                .Select(y => new
                {
                    BrandId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z => z.Count).FirstOrDefault();

            var brandName = _context.Brands.Where(x => x.BrandId == values.BrandId).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            int id = _context.Piricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.CarPricingId == id).Average(x => x.Ammount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Piricings.Where(x => x.Name == "Aylık").Select(y => y.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.CarPricingId == id).Average(x => x.Ammount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Piricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.CarPricingId == id).Average(x => x.Ammount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetCarBrandAndModeByRentPriceDailyMax()
        {
            int princingId = _context.Piricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PiricingId == princingId).Max(x => x.Ammount);
            int carId = _context.CarPricings.Where(x => x.Ammount == amount).Select(x => x.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModeByRentPriceDailyMin()
        {
            int princingId = _context.Piricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PiricingId == princingId).Min(x => x.Ammount);
            int carId = _context.CarPricings.Where(x => x.Ammount == amount).Select(x => x.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }
        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km < 1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}