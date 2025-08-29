using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarbook.Dto.FooterAdressDtos;

namespace UdemyCarbook.WebUI.ViewComponents.FooterAddressComponents
{
    public class _FooterAddressComponentPartial:ViewComponent
    {
        private readonly HttpClient client;

        public _FooterAddressComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responsMessage = await client.GetAsync("https://localhost:7126/api/FooterAddress/1");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultFeatureAddressDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
