using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.RegisterDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class RegisterApiService : IRegisterApiService
    {
        private readonly HttpClient _client;

        public RegisterApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<bool> CreateUserAsync(CreateRegisterDto dto)
            => (await _client.PostAsJsonAsync("Registers/CreateUser", dto)).IsSuccessStatusCode;
    }
}
