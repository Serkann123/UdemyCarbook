using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.StatisticsDtos;

namespace UdemyCarbook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardComponentPartial : ViewComponent
    {
        private readonly HttpClient client;

        public _AdminDashboardComponentPartial(IHttpClientFactory httpClientFactory)
        {
             client = httpClientFactory.CreateClient("CarApi");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
           
            #region
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCount");
            if (responsMessage.IsSuccessStatusCode)
            {
                int sayi = random.Next(0, 101);
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v = values.CarCount;
                ViewBag.v1 = sayi;
            }
            #endregion

            #region
            var responsMessage2 = await client.GetAsync("https://localhost:7126/api/Statistics/GetLocationQuery");
            if (responsMessage2.IsSuccessStatusCode)
            {
                int sayi2 = random.Next(0, 101);
                var jsonData2 = await responsMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.LokasyonCount = values2.LocationCount;
                ViewBag.LokasyonCountRandom = sayi2;
            }
            #endregion

            #region
            var responsMessage5 = await client.GetAsync("https://localhost:7126/api/Statistics/GetBrandCount");
            if (responsMessage5.IsSuccessStatusCode)
            {
                int sayi5 = random.Next(0, 101);
                var jsonData5 = await responsMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.BrandCount = values5.BrandCount;
                ViewBag.BrandCountRandom = sayi5;
            }
            #endregion

            #region
            var responsMessage6 = await client.GetAsync("https://localhost:7126/api/Statistics/GetAvgRentPriceForDaily");
            if (responsMessage6.IsSuccessStatusCode)
            {
                int sayi6 = random.Next(0, 101);
                var jsonData6 = await responsMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.GetAvgRentPriceForDaily = values6.avgRentPriceForDaily.ToString("0.00");
                ViewBag.GetAvgRentPriceForDailyRandom = sayi6;
            }
            #endregion

            return View();
        }
    }
}
