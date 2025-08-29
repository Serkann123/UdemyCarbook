using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.TestimonialDtos;

namespace UdemyCarbook.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _HttpCleintFactory;

        public _TestimonialComponentPartial(IHttpClientFactory httpCleintFactory)
        {
            _HttpCleintFactory = httpCleintFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpCleintFactory.CreateClient();
            var ressponsMessage = await client.GetAsync("https://localhost:7126/api/TestiMonial");
            if (ressponsMessage.IsSuccessStatusCode)
            {
                var jsonData = await ressponsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}
