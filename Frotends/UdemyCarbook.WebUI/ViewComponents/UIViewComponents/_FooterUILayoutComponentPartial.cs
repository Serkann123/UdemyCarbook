using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.FooterAdressDtos;
using System.Net.Http;
using System.Threading.Tasks;

namespace UdemyCarbook.WebUI.ViewComponents.UIViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        private readonly HttpClient client;

        public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responseMessage = await client.GetAsync("FooterAddress/1");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultFeatureAddressDto>(jsonData);

                return View(value);
            }

            return View();
        }
    }
}
