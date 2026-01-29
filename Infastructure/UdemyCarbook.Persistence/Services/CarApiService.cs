using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarDtos;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class CarApiService : ICarApiService
    {
        private readonly HttpClient _client;

        public CarApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }
        public async Task<List<ResultCarWithBrandDto>> GetAllAsync()
              => await _client.GetFromJsonAsync<List<ResultCarWithBrandDto>>("Cars") ?? new();

        public async Task<UpdateCarDto?> GetByIdAsync(int id)
            => await _client.GetFromJsonAsync<UpdateCarDto>($"Cars/{id}");

        public async Task<bool> CreateAsync(CreateCarDto dto)
            => (await _client.PostAsJsonAsync("Cars", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateCarDto dto)
            => (await _client.PutAsJsonAsync("Cars", dto)).IsSuccessStatusCode;

        public async Task<bool> RemoveAsync(int id)
            => (await _client.DeleteAsync($"Cars/{id}")).IsSuccessStatusCode;
    }
}
