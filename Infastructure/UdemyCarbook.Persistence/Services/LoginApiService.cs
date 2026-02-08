using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.LoginDtos;
using UdemyCarbook.WebUI.Models;

namespace UdemyCarbook.Persistence.Services
{
    public class LoginApiService : ILoginApiService
    {
        private readonly HttpClient _client;

        public LoginApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<JwtTokenDto?> LoginAsync(ResultLoginDto dto)
        {
            var response = await _client.PostAsJsonAsync("Login", dto);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content.ReadFromJsonAsync<JwtTokenDto>();
        }
    }
}