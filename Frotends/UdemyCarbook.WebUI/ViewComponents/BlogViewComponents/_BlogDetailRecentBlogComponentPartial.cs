using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.BlogDtos;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailRecentBlogComponentPartial:ViewComponent
    {
        private readonly HttpClient client;

        public _BlogDetailRecentBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Blog/GetLast3BlogsWithAuthorsList");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlog3WithBrandsAuthorsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
