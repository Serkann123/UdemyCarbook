using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarFeatures;
using UdemyCarbook.Dto.FeatureDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class CarFeatureApiService : ICarFeatureApiService
    {
        private readonly HttpClient _client;

        public CarFeatureApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultCarFeatureByCarIdResultDto>> GetByCarIdAsync(int carId)
        {
            return await _client.GetFromJsonAsync<List<ResultCarFeatureByCarIdResultDto>>
                ($"CarFeatures?id={carId}") ?? new List<ResultCarFeatureByCarIdResultDto>();
        }

        public async Task UpdateCarFeatureAvailableListAsync(List<ResultCarFeatureByCarIdResultDto> values)
        {
            var updateData = values.Select(x => new {
                CarFeatureId = x.CarFeatureId,
                Available = x.Available
            }).ToList();

            await _client.PutAsJsonAsync("CarFeatures/UpdateCarFeatureAvailableChangeList", updateData);
        }
        public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFeatureDto>>("Features")
                   ?? new List<ResultFeatureDto>();
        }
    }
}
