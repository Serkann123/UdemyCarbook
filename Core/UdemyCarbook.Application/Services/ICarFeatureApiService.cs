using UdemyCarbook.Dto.CarFeatures;
using UdemyCarbook.Dto.FeatureDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ICarFeatureApiService
    {
        Task<List<ResultCarFeatureByCarIdResultDto>> GetByCarIdAsync(int carId);
        Task<bool> SetAvailableAsync(int carFeatureId, bool available);
        Task<bool> UpdateAvailabilityBatchAsync(List<ResultCarFeatureByCarIdResultDto> items);
        Task<List<ResultFeatureDto>> GetAllFeaturesAsync();
    }
}
