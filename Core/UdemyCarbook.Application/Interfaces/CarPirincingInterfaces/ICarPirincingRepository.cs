using UdemyCarbook.Application.ViewsModel;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarPirincingInterfaces
{
    public interface ICarPirincingRepository
    {
        Task<List<CarPricing>> GetCarPirincingWihCarsAsync();
        Task<List<CarPrincingViewModel>> GetCarPricingWithTimePeriodAsync();
    }
}
