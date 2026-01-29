using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CarPirincingDtos;

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
