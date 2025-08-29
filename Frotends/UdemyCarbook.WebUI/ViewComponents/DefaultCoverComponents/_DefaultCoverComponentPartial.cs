using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarbook.Dto.BannerDtos;

namespace UdemyCarbook.WebUI.ViewComponents.DefaultCoverComponents
{
    public class _DefaultCoverComponentPartial:ViewComponent
    {
        private readonly HttpClient client;

        public _DefaultCoverComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responsMessage = await client.GetAsync("Banners");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
