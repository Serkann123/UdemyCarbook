using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.BlogDtos;

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
                var values = JsonConvert.DeserializeObject<GetBlogByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
