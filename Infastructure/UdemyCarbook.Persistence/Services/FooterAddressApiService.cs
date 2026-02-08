using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.FooterAdressDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class FooterAddressApiService : IFooterAddressApiService
    {
        private readonly HttpClient _client;

        public FooterAddressApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultFeatureAddressDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultFeatureAddressDto>>("FooterAddress")
                   ?? new List<ResultFeatureAddressDto>();
        }

        public async Task<UpdateFooterAddressDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateFooterAddressDto>($"FooterAddress/{id}");
        }

        public async Task<bool> CreateAsync(CreateFooterAddressDto dto)
            => (await _client.PostAsJsonAsync("FooterAddress", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateFooterAddressDto dto)
        {
            var response = await _client.PutAsJsonAsync("FooterAddress", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"FooterAddress/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
