using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.PirincingDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class PricingApiService : IPricingApiService
    {
        private readonly HttpClient _client;

        public PricingApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultPricingDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultPricingDto>>("Pirincings")
                   ?? new List<ResultPricingDto>();
        }
        public async Task<UpdatePrincingDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdatePrincingDto>($"Pirincings/{id}");
        }

        public async Task<bool> CreateAsync(CreatePrincingDto dto)
            => (await _client.PostAsJsonAsync("Pirincings", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdatePrincingDto dto)
        {
            var response = await _client.PutAsJsonAsync("Pirincings", dto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Pirincings/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
