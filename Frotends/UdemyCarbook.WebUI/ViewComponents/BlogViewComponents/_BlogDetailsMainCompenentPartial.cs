using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarbook.Dto.BlogDtos;
using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainCompenentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _BlogDetailsMainCompenentPartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _HttpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync($"https://localhost:7126/api/Blog/" + id);
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);

                var CommentCountResponse = await client.GetAsync("https://localhost:7126/api/Comments/CommentCountByBlog?id=" + id);
                var jsonData2 = await CommentCountResponse.Content.ReadAsStringAsync();
                var commentCountObj = JsonConvert.DeserializeObject<CommentCountDto>(jsonData2);
                ViewBag.commentCount = commentCountObj.CommentBlogCount;

                return View(value);
            }
            return View();
        }
    }
}
