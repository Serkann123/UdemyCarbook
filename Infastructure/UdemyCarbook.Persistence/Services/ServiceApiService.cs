using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.ServiceDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class ServiceApiService : IServiceApiService
    {
        private readonly HttpClient _client;
        public ServiceApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }
        public async Task<List<ResultServiceDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultServiceDto>>("Services")
                   ?? new List<ResultServiceDto>();
        }
        public async Task<UpdateServiceDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateServiceDto>($"Services/{id}");
        }

        public async Task<(bool ok, HttpResponseMessage? response)> CreateAsync(CreateServiceDto dto)
        {
            var response = await _client.PostAsJsonAsync("Services", dto);
            return (response.IsSuccessStatusCode, response);
        }
        public async Task<(bool ok, HttpResponseMessage? response)> UpdateAsync(UpdateServiceDto dto)
        {
            var response = await _client.PutAsJsonAsync("Services", dto);
            return (response.IsSuccessStatusCode, response);
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Services/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
