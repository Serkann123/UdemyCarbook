using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.TestimonialDtos;

namespace UdemyCarbook.WebUI.ViewComponents.TestimonialViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly HttpClient client;

        public _TestimonialComponentPartial(IHttpClientFactory httpCleintFactory)
        {
            client = httpCleintFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var ressponsMessage = await client.GetAsync("Testimonial");
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
