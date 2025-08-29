using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarbook.Dto.BlogDtos;
using UdemyCarbook.Dto.CommentDtos;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainCompenentPartial : ViewComponent
    {
        private readonly HttpClient client;

        public _BlogDetailsMainCompenentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var responsMessage = await client.GetAsync($"Blog/" + id);
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);

                var CommentCountResponse = await client.GetAsync("Comments/CommentCountByBlog?id=" + id);
                var jsonData2 = await CommentCountResponse.Content.ReadAsStringAsync();
                var commentCountObj = JsonConvert.DeserializeObject<CommentCountDto>(jsonData2);
                ViewBag.commentCount = commentCountObj.CommentBlogCount;

                return View(value);
            }
            return View();
        }
    }
}
