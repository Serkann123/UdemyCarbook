using Microsoft.AspNetCore.Mvc;
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

            #region Araba Sayısı
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

            #region Konum Sayısı
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

            #region Blog Sayısı
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

            #region Yazar Sayısı
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

            #region Marka Sayısı
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

            #region Günlük Kiralama
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

            #region Haftalık Kiralama
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

            #region Aylık Kiralama
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

            #region Otomatik Vitesli Araç Sayısı
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

            #region Kilometresi 1000'den az olan araçların sayısı
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

            #region Yakıt türü benzinli veya dizel olan araçların sayısı
            var responsMessage13 = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responsMessage13.IsSuccessStatusCode)
            {
                int sayi13 = random.Next(0, 101);
                var jsonData13 = await responsMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData13);
                ViewBag.GetCarCountByFuelGasolineOrDiesel = values13.carCountByFuelGasolineOrDiesel;
                ViewBag.GetCarCountByFuelGasolineOrDieselRandom = sayi13;
            }
            #endregion

            #region Yakıt türü elektrikli olan araçların sayısı
            var responsMessage14 = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarCountByFuelElectric");
            if (responsMessage14.IsSuccessStatusCode)
            {
                int sayi14 = random.Next(0, 101);
                var jsonData14 = await responsMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData14);
                ViewBag.GetCarCountByFuelElectric = values14.carCountByFuelElectric;
                ViewBag.GetCarCountByFuelElectricRandom = sayi14;
            }
            #endregion

            #region Günlük kiralama fiyatı en yüksek olan aracın marka ve model bilgilerinin Sayısı
            var responsMessage15 = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarBrandAndModeByRentPriceDailyMax");
            if (responsMessage15.IsSuccessStatusCode)
            {
                int sayi15 = random.Next(0, 101);
                var jsonData15 = await responsMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData15);
                ViewBag.carBrandAndModeByRentPriceDailyMax = values15.carBrandAndModeByRentPriceDailyMax;
                ViewBag.carBrandAndModeByRentPriceDailyMaxRandom = sayi15;
            }
            #endregion

            #region Günlük kiralama fiyatı en düşük olan aracın marka ve model bilgilerinin Sayısı
            var responsMessage16 = await client.GetAsync("https://localhost:7126/api/Statistics/GetCarBrandAndModeByRentPriceDailyMin");
            if (responsMessage16.IsSuccessStatusCode)
            {
                int sayi16 = random.Next(0, 101);
                var jsonData16 = await responsMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData16);
                ViewBag.carBrandAndModeByRentPriceDailyMin = values16.carBrandAndModeByRentPriceDailyMin;
                ViewBag.carBrandAndModeByRentPriceDailyMinRandom = sayi16;
            }
            #endregion

            #region En fazla araca sahip marka adını döndüren sorgudur
            var responsMessage20 = await client.GetAsync("https://localhost:7126/api/Statistics/GetBrandNameByMaxCar");
            if (responsMessage20.IsSuccessStatusCode)
            {
                int sayi20 = random.Next(0, 101);
                var jsonData20 = await responsMessage20.Content.ReadAsStringAsync();
                var values20 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData20);
                ViewBag.GetBrandNameByMaxCar = values20.brandNameByMaxCar;
                ViewBag.GetBrandNameByMaxCarRandom = sayi20;
            }
            #endregion

            #region En fazla yoruma sahip blogun başlığını döndüren sorgudur
            var responsMessage21 = await client.GetAsync("https://localhost:7126/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responsMessage21.IsSuccessStatusCode)
            {
                int sayi21 = random.Next(0, 101);
                var jsonData21 = await responsMessage21.Content.ReadAsStringAsync();
                var values21 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData21);
                ViewBag.GetBlogTitleByMaxBlogComment = values21.blogTitleByMaxBlogComment;
                ViewBag.GetBlogTitleByMaxBlogCommentRandom = sayi21;
            }
            #endregion

            return View();
        }
    }
}
