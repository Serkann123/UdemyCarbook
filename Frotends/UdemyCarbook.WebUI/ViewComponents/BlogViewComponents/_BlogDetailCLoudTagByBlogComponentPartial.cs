using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.TagCloudDtos;

namespace UdemyCarbook.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailCLoudTagByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _BlogDetailCLoudTagByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7126/api/TagClouds/GetTagCloudByBlogId?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetByBlogIdTagCloudDto>>(jsonData);

                var limitedValues = values.Take(10).ToList();

                return View(limitedValues);
            }
            return View();
        }
    }
}
