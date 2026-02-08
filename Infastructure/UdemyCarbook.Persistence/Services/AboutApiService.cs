using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.AboutDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class AboutApiService : IAboutApiService
    {
        private readonly HttpClient _client;

        public AboutApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultAboutDto>>("Abouts")
                ?? new List<ResultAboutDto>();
        }

        public async Task<UpdateAboutDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateAboutDto>($"Abouts/{id}");
        }

        public async Task<bool> CreateAsync(CreateAboutDto dto)
           => (await _client.PostAsJsonAsync("Abouts", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateAboutDto dto)
        {
            var response = await _client.PutAsJsonAsync("Abouts", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Abouts/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
