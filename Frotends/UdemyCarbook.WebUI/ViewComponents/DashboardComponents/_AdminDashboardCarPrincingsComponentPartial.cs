using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardCarPrincingsComponentPartial:ViewComponent
    {
        private readonly HttpClient client;

        public _AdminDashboardCarPrincingsComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var responsMessage = await client.GetAsync("https://localhost:7126/api/CarPrincings/GetCarPrincingWithTimePeriodQuery");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPrincingListModelDto>>(jsonData);
                return View(values);
            }
            return View();
        }

    }
}
