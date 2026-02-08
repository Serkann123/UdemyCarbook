using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.ReservationDtos;
using UdemyCarbook.WebUI.Models;

namespace UdemyCarbook.Persistence.Services
{
    public class ReservationApiService : IReservationApiService
    {
        private readonly HttpClient _client;
        public ReservationApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<ApiPostResult> CreateAsync(CreateReservationDto dto)
        {
            var response = await _client.PostAsJsonAsync("Reservations", dto);
            return await ToApiPostResult(response);
        }

        public async Task<List<ResultPendingDto>> GetPendingReservationsAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultPendingDto>>("Reservations/pending")
                ?? new List<ResultPendingDto>();
        }

        public async Task<ApiPostResult> ApproveAsync(int reservationId)
        {
            var response = await _client.PostAsync($"Reservations/{reservationId}/approve", content: null);
            return await ToApiPostResult(response);
        }

        public async Task<ApiPostResult> RejectAsync(int reservationId)
        {
            var response = await _client.PostAsync($"Reservations/{reservationId}/reject", content: null);
            return await ToApiPostResult(response);
        }
        private static async Task<ApiPostResult> ToApiPostResult(HttpResponseMessage response)
        {
            return new ApiPostResult
            {
                Success = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode,
                ReasonPhrase = response.ReasonPhrase,
                RawBody = await response.Content.ReadAsStringAsync()
            };
        }
    }
}
