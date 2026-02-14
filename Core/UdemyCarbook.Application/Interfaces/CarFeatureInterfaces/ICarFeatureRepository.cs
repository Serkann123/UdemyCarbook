using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeatureByCarIdAsync(int carId);
        Task UpdateCarFeatureAvailableAsync(int carFeatureId, bool available);
        Task SaveChangesAsync();
    }
}
