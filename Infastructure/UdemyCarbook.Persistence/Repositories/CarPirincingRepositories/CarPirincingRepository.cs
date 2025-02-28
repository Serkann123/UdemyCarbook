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
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Piricing).Where(x => x.PiricingId == 2).ToList();
            return values;
        }

        public List<CarPrincingViewModel> GetCarPricingWithTimePeriod1()
        {
            List<CarPrincingViewModel> values = new List<CarPrincingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,CoverImageUrl,PiricingId,Ammount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Cars.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Ammount) For PiricingId In ([1],[2],[3])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        CarPrincingViewModel carPrincingViewModel = new CarPrincingViewModel()
                        {
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),

                            Amounts = new List<decimal>
                           {
                            reader.IsDBNull(2) ? 0m : Convert.ToDecimal(reader[2]),
                            reader.IsDBNull(3) ? 0m : Convert.ToDecimal(reader[3]),
                            reader.IsDBNull(4) ? 0m : Convert.ToDecimal(reader[4]),
                           }

                        };
                        values.Add(carPrincingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}