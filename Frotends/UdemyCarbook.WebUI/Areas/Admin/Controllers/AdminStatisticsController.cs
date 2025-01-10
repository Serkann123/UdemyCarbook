﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarbook.Dto.StatisticsDtos;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

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
            var responsMessage3 = await client.GetAsync("https://localhost:7126/api/Statistics/GetBlogCount");
            if (responsMessage3.IsSuccessStatusCode)
            {
                int sayi3 = random.Next(0, 101);
                var jsonData3 = await responsMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.BlogCount = values3.BlogCount;
                ViewBag.BlogCountRandom = sayi3;
            }
            #endregion

            #region
            var responsMessage4 = await client.GetAsync("https://localhost:7126/api/Statistics/GetAuthorCount");
            if (responsMessage4.IsSuccessStatusCode)
            {
                int sayi4 = random.Next(0, 101);
                var jsonData4 = await responsMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.AuthorCount = values4.AuthorCount;
                ViewBag.AuthorCountRandom = sayi4;
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

            #region
            var responsMessage7 = await client.GetAsync("https://localhost:7126/api/Statistics/GetAvgRentPriceForWeekly");
            if (responsMessage7.IsSuccessStatusCode)
            {
                int sayi7 = random.Next(0, 101);
                var jsonData7 = await responsMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.GetAvgRentPriceForWeekly = values7.avgRentPriceForWeekly.ToString("0.00");
                ViewBag.GetAvgRentPriceForWeeklyRandom = sayi7;
            }
            #endregion

            #region
            var responsMessage8 = await client.GetAsync("https://localhost:7126/api/Statistics/GetAvgRentPriceForMonthly");
            if (responsMessage8.IsSuccessStatusCode)
            {
                int sayi8 = random.Next(0, 101);
                var jsonData8 = await responsMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.getAvgRentPriceForMonthly = values8.getAvgRentPriceForMonthly.ToString("0.00");
                ViewBag.getAvgRentPriceForMonthlyRandom = sayi8;
            }
        #endregion

            #region
            var responsMessage9 = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCountByTranmissionIsAuto");
            if (responsMessage9.IsSuccessStatusCode)
            {
                int sayi9 = random.Next(0, 101);
                var jsonData9 = await responsMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.carCountByTranmissionIsAuto = values9.carCountByTranmissionIsAuto;
                ViewBag.carCountByTranmissionIsAutoRandom = sayi9;
            }
            #endregion

            #region
            var responsMessage12 = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responsMessage12.IsSuccessStatusCode)
            {
                int sayi12 = random.Next(0, 101);
                var jsonData12 = await responsMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.carCountByKmSmallerThen1000 = values12.carCountByKmSmallerThen1000;
                ViewBag.carCountByKmSmallerThen1000Random = sayi12;
            }
            #endregion

            return View();
        }
        public ActionResult deneme()
        {
            return View();
        }
    }
}