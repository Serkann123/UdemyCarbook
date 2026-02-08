using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.AuthorDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class AuthorApiService : IAuthorApiService
    {
        private readonly HttpClient _client;
        public AuthorApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }
        public async Task<List<ResultAuthorDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultAuthorDto>>("Author")
                   ?? new List<ResultAuthorDto>();
        }
        public async Task<UpdateAuthorDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateAuthorDto>($"Author/{id}");
        }

        public async Task<bool> CreateAsync(CreateAuthorDto dto)
           => (await _client.PostAsJsonAsync("Author", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateAuthorDto dto)
        {
            var response = await _client.PutAsJsonAsync("Author", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Author/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
