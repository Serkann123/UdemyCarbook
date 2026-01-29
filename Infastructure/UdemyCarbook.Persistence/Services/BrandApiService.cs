using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.BrandDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class BrandApiService : IBrandApiService
    {
        private readonly HttpClient _client;

        public BrandApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultBrandDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultBrandDto>>("Brands") ?? new List<ResultBrandDto>();
        }

        public async Task<UpdateBrandDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateBrandDto>($"Brands/{id}");
        }

        public async Task<bool> CreateAsync(CreateBrandDto dto)
        {
            var responseMessage = await _client.PostAsJsonAsync("Brands", dto);

            return responseMessage.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(UpdateBrandDto dto)
        {
            var responseMessage = await _client.PutAsJsonAsync("Brands", dto);
            return responseMessage.IsSuccessStatusCode;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Brands/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
