using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ICarPricingApiService
    {
        Task<List<T>> GetCarPricingWithTimePeriodAsync<T>();
    }
}
