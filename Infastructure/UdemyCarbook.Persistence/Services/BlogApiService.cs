using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Services;
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
        {
            return await _client.GetFromJsonAsync<List<ResultBlogsAllWithAuthorDto>>(
                "Blog/GetBlogsAllWithAuthorsList"
            ) ?? new();
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _client.DeleteAsync($"Blog/{id}");
            return response.IsSuccessStatusCode;
        }

        

    }
}
