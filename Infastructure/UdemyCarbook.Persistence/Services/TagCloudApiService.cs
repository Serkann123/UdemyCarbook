using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.TagCloudDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class TagCloudApiService : ITagCloudApiService
    {
        private readonly HttpClient _client;

        public TagCloudApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<GetByBlogIdTagCloudDto>> GetByBlogIdAsync(int blogId)
        {
            return await _client.GetFromJsonAsync<List<GetByBlogIdTagCloudDto>>(
                $"TagClouds/GetTagCloudByBlogId?id={blogId}") ?? new();
        }
    }
}