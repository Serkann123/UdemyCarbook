using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.SocialMediaDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class SocialMediaApiService : ISocialMediaApiService
    {
        private readonly HttpClient _client;

        public SocialMediaApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultSocialMediaDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("SocialMedias")
                   ?? new List<ResultSocialMediaDto>();
        }

        public async Task<UpdateSocialMediaDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateSocialMediaDto>($"SocialMedias/{id}");
        }

        public async Task<bool> CreateAsync(CreateSocialMediaDto dto)
            => (await _client.PostAsJsonAsync("SocialMedias", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateSocialMediaDto dto)
            => (await _client.PutAsJsonAsync("SocialMedias", dto)).IsSuccessStatusCode;

        public async Task<bool> RemoveAsync(int id)
            => (await _client.DeleteAsync($"SocialMedias/{id}")).IsSuccessStatusCode;
    }
}
