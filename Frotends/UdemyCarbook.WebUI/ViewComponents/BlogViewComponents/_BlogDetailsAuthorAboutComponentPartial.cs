using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.AuthorDtos;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsAuthorAboutComponentPartial:ViewComponent
    {
        private readonly HttpClient client;

        public _BlogDetailsAuthorAboutComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var responsMessage = await client.GetAsync($"Blog/getBlogByAuthorId?id={id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlogByAuthorIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}


