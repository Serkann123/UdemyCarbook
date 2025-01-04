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
            throw new NotImplementedException();
        }

        public string GetBrandNameByMaxCar()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public string GetCarBrandAndModeByRentPriceDailyMin()
        {
            throw new NotImplementedException();
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