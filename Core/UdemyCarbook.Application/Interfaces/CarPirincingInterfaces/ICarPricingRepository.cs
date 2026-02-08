using UdemyCarbook.Application.ViewsModel;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarPirincingInterfaces
{
    public interface ICarPricingRepository
    {
        Task<List<CarPricing>> GetCarPirincingWihCarsAsync();
        Task<List<CarPrincingViewModel>> GetCarPricingWithTimePeriodAsync();
        Task<decimal?> GetAmountAsync(int carId, string pricingName);
    }
}
