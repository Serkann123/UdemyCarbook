using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarDescriptionDtos;
using UdemyCarbook.Dto.CarDtos;

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

        public async Task<List<ResultCarForReservationDto>> GetCarWithBrandAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCarForReservationDto>>("Cars/GetCarWithBrand")
                ?? new();
        }

        public async Task<List<ResultLast5CarsWithBrandDto>> GetLast5CarsWithBrandAsync()
          => await _client.GetFromJsonAsync<List<ResultLast5CarsWithBrandDto>>("Cars/GetLast5CarsQueryHandler")
            ?? new();

        public async Task<ResultCarDescriptionByCarIdDto?> GetDescriptionByCarIdAsync(int carId)
            => await _client.GetFromJsonAsync<ResultCarDescriptionByCarIdDto>(
                   $"CarDescription/CarDetailByCarId?id={carId}");

        public async Task<ResultCarMainCarFeatureDto?> GetMainCarFeatureAsync(int carId)
            => await _client.GetFromJsonAsync<ResultCarMainCarFeatureDto>(
                $"Cars/GetCarMainCarFeature?id={carId}");
    }
}
