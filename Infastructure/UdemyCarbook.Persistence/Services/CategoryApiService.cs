using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CategoryDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class CategoryApiService : ICategoryApiService
    {
        private readonly HttpClient _client;
        public CategoryApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }
        public async Task<List<ResultCategoryDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCategoryDto>>("Categories")
                   ?? new List<ResultCategoryDto>();
        }
        public async Task<UpdateCategoryDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateCategoryDto>($"Categories/{id}");
        }

        public async Task<bool> CreateAsync(CreateCategoryDto dto)
            => (await _client.PostAsJsonAsync("Categories", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateCategoryDto dto)
        {
            var response = await _client.PutAsJsonAsync("Categories", dto);
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Categories/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
