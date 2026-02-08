using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.FeatureDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class FeatureApiService : IFeatureApiService
    {
        private readonly HttpClient _client;

        public FeatureApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultFeatureDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFeatureDto>>("Features")
                   ?? new List<ResultFeatureDto>();
        }

        public async Task<UpdateFeatureDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateFeatureDto>($"Features/{id}");
        }

        public async Task<bool> CreateAsync(CreateFeatureDto dto)
            => (await _client.PostAsJsonAsync("Features", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateFeatureDto dto)
        {
            var response = await _client.PutAsJsonAsync("Features", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Features/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
