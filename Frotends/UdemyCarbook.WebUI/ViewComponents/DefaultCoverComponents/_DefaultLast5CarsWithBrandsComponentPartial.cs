using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.CarDtos;

namespace UdemyCarbook.WebUI.ViewComponents.DefaultCoverComponents
{
    public class _DefaultLast5CarsWithBrandsComponentPartial:ViewComponent
    {
        private readonly HttpClient client;

        public _DefaultLast5CarsWithBrandsComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responsMessage = await client.GetAsync("Cars/GetLast5CarsQueryHandler");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLast5CarsWithBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
