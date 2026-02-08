using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.RentACarFilterDtos;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.Persistence.Services
{
    public class RentACarApiService : IRentACarApiService
    {
        private readonly HttpClient _client;

        public RentACarApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<FilterRentACarDto>> GetAvailableAsync(RentSearchDto query)
        {
            return await _client.GetFromJsonAsync<List<FilterRentACarDto>>(
               $"RentACars/available?" +
               $"LocationId={query.LocationId}" +
               $"&PickUp={query.PickUp:yyyy-MM-ddTHH:mm}" +
               $"&DropOff={query.DropOff:yyyy-MM-ddTHH:mm}"
            ) ?? new();
        }
    }
}
