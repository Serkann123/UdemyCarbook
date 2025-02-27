using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.ViewsModel;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarPirincingInterfaces
{
    public interface ICarPirincingRepository
    {
        List<CarPricing> GetCarPirincingWihCars();
        List<CarPrincingViewModel> GetCarPricingWithTimePeriod1();
    }
}
