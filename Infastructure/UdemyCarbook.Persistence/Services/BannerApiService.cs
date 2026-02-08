using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.BannerDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class BannerApiService : IBannerApiService
    {
        private readonly HttpClient _client;
        public BannerApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultBannerDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultBannerDto>>("Banners")
                   ?? new List<ResultBannerDto>();
        }
        public async Task<UpdateBannerDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateBannerDto>($"Banners/{id}");
        }

        public async Task<bool> CreateAsync(CreateBannerDto dto)
            => (await _client.PostAsJsonAsync("Banners", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateBannerDto dto)
        {
            var response = await _client.PutAsJsonAsync("Banners", dto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Banners/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}