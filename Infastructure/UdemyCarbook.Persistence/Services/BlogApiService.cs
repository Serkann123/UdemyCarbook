using System.Net.Http.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.AuthorDtos;
using UdemyCarbook.Dto.BlogDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class BlogApiService : IBlogApiService
    {
        private readonly HttpClient _client;

        public BlogApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }
        public async Task<List<ResultBlogsAllWithAuthorDto>> GetBlogsAllWithAuthorsAsync()
           => await _client.GetFromJsonAsync<List<ResultBlogsAllWithAuthorDto>>(
               "Blog/GetBlogsAllWithAuthorsList") ?? new();

        public async Task<GetBlogByIdDto?> GetByIdAsync(int id)
            => await _client.GetFromJsonAsync<GetBlogByIdDto>($"Blog/{id}");

        public async Task<List<ResultBlog3WithBrandsAuthorsDto>> GetLast3WithAuthorsAsync()
            => await _client.GetFromJsonAsync<List<ResultBlog3WithBrandsAuthorsDto>>(
                "Blog/GetLast3BlogsWithAuthorsList") ?? new();

        public async Task<List<ResultBlogByAuthorIdDto>> GetByAuthorIdAsync(int authorId)
            => await _client.GetFromJsonAsync<List<ResultBlogByAuthorIdDto>>(
                $"Blog/getBlogByAuthorId?id={authorId}") ?? new();

        public async Task<bool> RemoveAsync(int id)
            => (await _client.DeleteAsync($"Blog/{id}")).IsSuccessStatusCode;
    }
}
