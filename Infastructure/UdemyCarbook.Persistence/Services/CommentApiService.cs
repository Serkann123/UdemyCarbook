using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class CommentApiService : ICommentApiService
    {
        private readonly HttpClient _client;

        public CommentApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<List<ResultCommentDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultCommentDto>>("Comments")
                   ?? new List<ResultCommentDto>();
        }

        public async Task<List<ResultCommentDto>> GetByBlogIdAsync(int id)
        {
           return await _client.GetFromJsonAsync<List<ResultCommentDto>>(
               $"Comments/CommentListByBlog/{id}") ?? new();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Comments/{id}");
            return response.IsSuccessStatusCode;
        }
        public async Task<bool> CreateAsync(CreateCommentDto dto)
            => (await _client.PostAsJsonAsync("Comments", dto)).IsSuccessStatusCode;

        public async Task<CommentCountDto?> GetCountByBlogIdAsync(int blogId)
             => await _client.GetFromJsonAsync<CommentCountDto>($"Comments/CommentCountByBlog?id={blogId}");
    }
}
