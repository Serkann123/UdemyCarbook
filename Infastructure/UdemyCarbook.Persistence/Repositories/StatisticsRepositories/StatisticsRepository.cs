using Microsoft.EntityFrameworkCore;
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

        public async Task<string> GetBlogTitleByMaxBlogCommentAsync()
        {
            var values = await _context.Comments.GroupBy(x => x.BlogId)
                .Select(y => new
                {
                    BlogId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z => z.Count).FirstOrDefaultAsync();

            var titleName = await _context.Blogs.Where(x => x.BlogId == values.BlogId).Select(y => y.Title)
                .FirstOrDefaultAsync();
            return titleName;
        }

        public async Task<string> GetBrandNameByMaxCarAsync()
        {
            var values = await _context.Cars.GroupBy(x => x.BrandId)
                .Select(y => new
                {
                    BrandId = y.Key,
                    Count = y.Count()
                }).OrderByDescending(z => z.Count).FirstOrDefaultAsync();

            var brandName = await _context.Brands.Where(x => x.BrandId == values.BrandId).Select(y => y.Name).FirstOrDefaultAsync();
            return brandName;
        }

        public async Task<int> GetAuthorCountAsync()
        {
            return await _context.Authors.CountAsync();
        }

        public async Task<decimal> GetAvgRentPriceForDailyAsync()
        {
            int id = await _context.Piricings.Where(x => x.Name == "Günlük").Select(y => y.PricingId).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.CarPricingId == id).AverageAsync(x => x.Ammount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForMonthlyAsync()
        {
            int id = await _context.Piricings.Where(x => x.Name == "Aylık").Select(y => y.PricingId).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.CarPricingId == id).AverageAsync(x => x.Ammount);
            return value;
        }

        public async Task<decimal> GetAvgRentPriceForWeeklyAsync()
        {
            int id = await _context.Piricings.Where(x => x.Name == "Haftalık").Select(y => y.PricingId).FirstOrDefaultAsync();
            var value = await _context.CarPricings.Where(x => x.CarPricingId == id).AverageAsync(x => x.Ammount);
            return value;
        }

        public async Task<int> GetBlogCountAsync()
        {
            return await _context.Blogs.CountAsync();
        }

        public async Task<int> GetBrandCountAsync()
        {
            return await _context.Brands.CountAsync();
        }

        public async Task<string> GetCarBrandAndModeByRentPriceDailyMaxAsync()
        {
            int princingId = await _context.Piricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefaultAsync();
            decimal amount = await _context.CarPricings.Where(x => x.PiricingId == princingId).MaxAsync(x => x.Ammount);
            int carId = await _context.CarPricings.Where(x => x.Ammount == amount).Select(x => x.CarId).FirstOrDefaultAsync();
            string brandModel = await _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
        }

        public async Task<string?> GetCarBrandAndModeByRentPriceDailyMinAsync()
        {
            int princingId = await _context.Piricings.Where(x => x.Name == "Günlük").Select(x => x.PricingId).FirstOrDefaultAsync();
            decimal amount = await _context.CarPricings.Where(x => x.PiricingId == princingId).MinAsync(x => x.Ammount);
            int carId = await _context.CarPricings.Where(x => x.Ammount == amount).Select(x => x.CarId).FirstOrDefaultAsync();
            string brandModel = await _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefaultAsync();
            return brandModel;
        }

        public async Task<int> GetCarCountAsync()
        {
            return await _context.Cars.CountAsync();
        }

        public async Task<int> GetCarCountByFuelElectricAsync()
        {
            return await _context.Cars.Where(x => x.Fuel == "Elektrik").CountAsync();
        }
        public async Task<int> GetCarCountByFuelGasolineOrDieselAsync()
        {
            return await _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").CountAsync();
        }

        public async Task<int> GetCarCountByKmSmallerThen1000Async()
        {
            return await _context.Cars.Where(x => x.Km < 1000).CountAsync();
        }

        public async Task<int> GetCarCountByTranmissionIsAutoAsync()
        {
            return await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
        }

        public async Task<int> GetLocationCountAsync()
        {
            return await _context.Locations.CountAsync();
        }
    }
}