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
            return await _client.GetFromJsonAsync<List<ResultCarFeatureByCarIdResultDto>>($"CarFeatures?id={carId}")
                   ?? new List<ResultCarFeatureByCarIdResultDto>();
        }

        public async Task<bool> SetAvailableAsync(int carFeatureId, bool available)
        {
            var url = available
                ? $"CarFeatures/CarFeatureChangeAvailableToTrue?id={carFeatureId}"
                : $"CarFeatures/CarFeatureChangeAvailableToFalse?id={carFeatureId}";

            var response = await _client.GetAsync(url);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAvailabilityBatchAsync(List<ResultCarFeatureByCarIdResultDto> items)
        {
            bool allOk = true;

            foreach (var item in items)
            {
                var ok = await SetAvailableAsync(item.CarFeatureId, item.Available);
                if (!ok) allOk = false;
            }

            return allOk;
        }

        public async Task<List<ResultFeatureDto>> GetAllFeaturesAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFeatureDto>>("Features")
                   ?? new List<ResultFeatureDto>();
        }
    }
}
