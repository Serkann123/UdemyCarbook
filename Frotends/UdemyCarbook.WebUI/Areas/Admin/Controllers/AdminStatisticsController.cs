using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Dto.StatisticsDtos;
using UdemyCarbook.WebUI.Models;

namespace UdemyCarbook.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AdminStatisticsController : Controller
    {
        private readonly GenericStatistics _statistics;

        public AdminStatisticsController(GenericStatistics statistics)
        {
            _statistics = statistics;
        }

        public async Task<IActionResult> Index()
        {
            #region Araba Sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
              ("https://localhost:7126/api/Statistics/GetCarCount",
               "CarCount", ViewData, x => x.CarCount);

            #endregion

            #region Konum Sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetLocationQuery",
             "LokasyonCount", ViewData, x => x.LocationCount);

            #endregion

            #region Blog Sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetBlogCount",
            "BlogCount", ViewData, x => x.BlogCount);

            #endregion

            #region Yazar Sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetAuthorCount",
            "AuthorCount", ViewData, x => x.AuthorCount);

            #endregion

            #region Marka Sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetBrandCount",
            "BrandCount", ViewData, x => x.BrandCount);

            #endregion

            #region Günlük Kiralama

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetAvgRentPriceForDaily",
            "GetAvgRentPriceForDaily", ViewData, x => x.avgRentPriceForDaily);

            #endregion

            #region Haftalık Kiralama

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetAvgRentPriceForWeekly",
            "GetAvgRentPriceForWeekly", ViewData, x => x.avgRentPriceForWeekly);

            #endregion

            #region Aylık Kiralama

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetAvgRentPriceForMonthly",
            "getAvgRentPriceForMonthly", ViewData, x => x.getAvgRentPriceForMonthly);

            #endregion

            #region Otomatik Vitesli Araç Sayısı
            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetCarCountByTranmissionIsAuto",
            "carCountByTranmissionIsAuto", ViewData, x => x.carCountByTranmissionIsAuto);

            #endregion

            #region Kilometresi 1000'den az olan araçların sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetCarCountByKmSmallerThen1000",
            "carCountByKmSmallerThen1000", ViewData, x => x.carCountByKmSmallerThen1000);

            #endregion

            #region Yakıt türü benzinli veya dizel olan araçların sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetCarCountByFuelGasolineOrDiesel",
            "GetCarCountByFuelGasolineOrDiesel", ViewData, x => x.carCountByFuelGasolineOrDiesel);

            #endregion

            #region Yakıt türü elektrikli olan araçların sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetCarCountByFuelElectric",
            "GetCarCountByFuelElectric", ViewData, x => x.carCountByFuelElectric);

            #endregion

            #region Günlük kiralama fiyatı en yüksek olan aracın marka ve model bilgilerinin Sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetCarBrandAndModeByRentPriceDailyMax",
            "carBrandAndModeByRentPriceDailyMax", ViewData, x => x.carBrandAndModeByRentPriceDailyMax);

            #endregion

            #region Günlük kiralama fiyatı en düşük olan aracın marka ve model bilgilerinin Sayısı

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetCarBrandAndModeByRentPriceDailyMin",
            "carBrandAndModeByRentPriceDailyMin", ViewData, x => x.carBrandAndModeByRentPriceDailyMin);

            #endregion

            #region En fazla araca sahip marka adını döndüren sorgudur

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetBrandNameByMaxCar",
            "GetBrandNameByMaxCar", ViewData, x => x.brandNameByMaxCar);

            #endregion

            #region En fazla yoruma sahip blogun başlığını döndüren sorgudur

            await _statistics.setViewBagData<ResultStatisticsDto>
            ("https://localhost:7126/api/Statistics/GetBlogTitleByMaxBlogComment",
            "GetBlogTitleByMaxBlogComment", ViewData, x => x.blogTitleByMaxBlogComment);

            #endregion
            return View();
        }
    }
}
