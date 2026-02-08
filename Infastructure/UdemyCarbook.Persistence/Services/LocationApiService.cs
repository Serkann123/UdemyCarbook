using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.LocationDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class LocationApiService : ILocationApiService
    {
        private readonly HttpClient _client;

        public LocationApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultLocationDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultLocationDto>>("Locations")
                   ?? new List<ResultLocationDto>();
        }
        public async Task<UpdateLocationDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateLocationDto>($"Locations/{id}");
        }
        public async Task<bool> CreateAsync(CreateLocationDto dto)
            => (await _client.PostAsJsonAsync("Locations", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateLocationDto dto)
        {
            var response = await _client.PutAsJsonAsync("Locations", dto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Locations/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
