using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<bool> CreateAsync(CreateCommentDto dto)
            => (await _client.PostAsJsonAsync("Comments", dto)).IsSuccessStatusCode;
    }
}
