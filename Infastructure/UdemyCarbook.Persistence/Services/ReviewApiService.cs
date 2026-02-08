using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.ReviewDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class ReviewApiService : IReviewApiService
    {
        private readonly HttpClient _client;

        public ReviewApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultReviewByCarIdDto>> GetByCarIdAsync(int carId)
            => await _client.GetFromJsonAsync<List<ResultReviewByCarIdDto>>(
                $"Review/GetReviewByCarId?id={carId}") ?? new();
    }
}
