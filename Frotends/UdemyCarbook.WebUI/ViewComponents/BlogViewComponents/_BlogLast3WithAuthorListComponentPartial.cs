using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.BlogDtos;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogLast3WithAuthorListComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _BlogLast3WithAuthorListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Blog/GetLast3BlogsWithAuthorsList");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBlog3WithBrandsAuthors>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
