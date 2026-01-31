using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrandAsync();
        Task<List<Car>> GetLast5WithCarsWithBrandAsync();
        Task<int> GetCarCountAsync();
        Task<Car> GetCarMainCarFeatureAsync(int id);
    }
}
