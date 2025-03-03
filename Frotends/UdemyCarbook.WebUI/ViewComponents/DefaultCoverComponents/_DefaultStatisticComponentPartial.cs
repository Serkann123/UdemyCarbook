using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using UdemyCarbook.Dto.StatisticsDtos;

namespace UdemyCarbook.WebUI.ViewComponents.DefaultCoverComponents
{
    public class _DefaultStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _DefaultStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();

            #region
            var responsMessage = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCount");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCount = values.CarCount;
            }
            #endregion

            #region
            var responsMessage2 = await client.GetAsync("https://localhost:7126/api/Statistics/GetLocationQuery");
            if (responsMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responsMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.LokasyonCount = values2.LocationCount;
            }
            #endregion

            #region
            var responsMessage3 = await client.GetAsync("https://localhost:7126/api/Statistics/GetBrandCount");
            if (responsMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responsMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.BrandCount = values3.BrandCount;
            }
            #endregion

            #region
            var responsMessage4 = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCountByFuelElectric");
            if (responsMessage4.IsSuccessStatusCode)
            {
                var jsonData4 = await responsMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.GetCarCountByFuelElectric = values4.carCountByFuelElectric;
            }
            #endregion

            return View();
        }
    }
}