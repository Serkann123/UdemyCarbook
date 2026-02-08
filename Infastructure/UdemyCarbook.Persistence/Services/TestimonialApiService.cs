using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.TestimonialDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class TestimonialApiService : ITestimonialApiService
    {
        private readonly HttpClient _client;

        public TestimonialApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("Testimonial")
                   ?? new List<ResultTestimonialDto>();
        }

        public async Task<UpdateTestimonialDto?> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateTestimonialDto>($"Testimonial/{id}");
        }

        public async Task<bool> CreateAsync(CreateTestimonialDto dto)
            => (await _client.PostAsJsonAsync("Testimonial", dto)).IsSuccessStatusCode;

        public async Task<bool> UpdateAsync(UpdateTestimonialDto dto)
            => (await _client.PutAsJsonAsync("Testimonial", dto)).IsSuccessStatusCode;

        public async Task<bool> RemoveAsync(int id)
            => (await _client.DeleteAsync($"Testimonial/{id}")).IsSuccessStatusCode;
    }
}
