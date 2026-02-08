using System.Net.Http.Json;
using UdemyCarbook.Application.Services;

namespace UdemyCarbook.Persistence.Services
{
    public class CarPricingApiService : ICarPricingApiService
    {
        private readonly HttpClient _client;

        public CarPricingApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }
        public async Task<List<T>> GetCarPricingWithTimePeriodAsync<T>()
                 => await _client.GetFromJsonAsync<List<T>>(
                     "CarPrincings/GetCarPrincingWithTimePeriodQuery"
                 ) ?? new();
    }
}
