using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        Task<List<CarFeature>> GetCarFeatureByCarIdAsync(int carId);
        Task ChangeCarFeaturesAvailableToFalseAsync(int id);
        Task ChangeCarFeaturesAvailableToTrueAsync(int id);
    }
}
