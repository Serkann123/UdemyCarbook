using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "GetCarPricingWithTimePeriodProc";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                _context.Database.OpenConnection();

                var result = new List<CarPrincingViewModel>();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new CarPrincingViewModel
                        {
                            Model = reader.GetString(0),
                            ModelName=reader.GetString(1),
                            BrandName=reader.GetString(2),
                            CoverImageUrl=reader.GetString(3),
                            DailyAmount = reader.IsDBNull(1) ? 0 : reader.GetDecimal(4),
                            WeeklyAmount = reader.IsDBNull(2) ? 0 : reader.GetDecimal(5),
                            MonthlyAmount = reader.IsDBNull(3) ? 0 : reader.GetDecimal(6),
                        });
                    }
                }
                return result;
            }
        }
    }
}
