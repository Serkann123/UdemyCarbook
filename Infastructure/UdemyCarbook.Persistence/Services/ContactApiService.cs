using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.ContactDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class ContactApiService : IContactApiService
    {
        private readonly HttpClient _client;

        public ContactApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultContactDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultContactDto>>("Contacts")
                   ?? new List<ResultContactDto>();
        }

        public async Task<bool> CreateAsync(CreateContactDto dto)
        {
            dto.SenDate = DateTime.Now;
            return (await _client.PostAsJsonAsync("Contacts", dto)).IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Contacts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
