using Newtonsoft.Json;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.StatisticsDtos;

namespace UdemyCarbook.Persistence.Services
{
    public class StatisticsApiService : IStatisticsApiService
    {
        private readonly HttpClient _client;
        public StatisticsApiService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("CarApi");
        }

        private async Task<ResultStatisticsDto> FetchAsync(string url)
        {
            var response = await _client.GetAsync($"Statistics/{url}");

            if (!response.IsSuccessStatusCode)
                return new ResultStatisticsDto();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResultStatisticsDto>(json) ?? new ResultStatisticsDto();
        }

        public async Task<GetDashboardDto> GetDashboardAsync()
        {
            // 1) Tüm İstekleri Aynı Anda Başlat
            var taskCar = FetchAsync("GetCarCount");
            var taskLoc = FetchAsync("GetLocationQuery");
            var taskBlog = FetchAsync("GetBlogCount");
            var taskAuthor = FetchAsync("GetAuthorCount");
            var taskBrand = FetchAsync("GetBrandCount");

            var taskDaily = FetchAsync("GetAvgRentPriceForDaily");
            var taskWeekly = FetchAsync("GetAvgRentPriceForWeekly");
            var taskMonthly = FetchAsync("GetAvgRentPriceForMonthly");

            var taskAuto = FetchAsync("GetCarCountByTranmissionIsAuto");
            var taskKm = FetchAsync("GetCarCountByKmSmallerThen1000");
            var taskGas = FetchAsync("GetCarCountByFuelGasolineOrDiesel");
            var taskElectric = FetchAsync("GetCarCountByFuelElectric");

            var taskMaxRent = FetchAsync("GetCarBrandAndModeByRentPriceDailyMax");
            var taskMinRent = FetchAsync("GetCarBrandAndModeByRentPriceDailyMin");
            var taskBrandMax = FetchAsync("GetBrandNameByMaxCar");
            var taskBlogMax = FetchAsync("GetBlogTitleByMaxBlogComment");

            // 2) Tüm Task'lerin Bitmesini Bekle
            await Task.WhenAll(
                taskCar, taskLoc, taskBlog, taskAuthor, taskBrand,
                taskDaily, taskWeekly, taskMonthly,
                taskAuto, taskKm, taskGas, taskElectric,
                taskMaxRent, taskMinRent, taskBrandMax, taskBlogMax
            );

            // 3) Task Sonuçlarını Al
            var car = await taskCar;
            var loc = await taskLoc;
            var blog = await taskBlog;
            var author = await taskAuthor;
            var brand = await taskBrand;

            var daily = await taskDaily;
            var weekly = await taskWeekly;
            var monthly = await taskMonthly;

            var auto = await taskAuto;
            var km = await taskKm;
            var gas = await taskGas;
            var electric = await taskElectric;

            var maxRent = await taskMaxRent;
            var minRent = await taskMinRent;
            var brandMax = await taskBrandMax;
            var blogMax = await taskBlogMax;

            // 4) // View’da kullanılacak modele atma yap
            return new GetDashboardDto
            {
                CarCount = car.CarCount,
                LocationCount = loc.LocationCount,
                BlogCount = blog.BlogCount,
                AuthorCount = author.AuthorCount,
                BrandCount = brand.BrandCount,

                AvgRentPriceDaily = daily.AvgPrice,
                AvgRentPriceWeekly = weekly.AvgPrice,
                AvgRentPriceMonthly = monthly.AvgPrice,

                AutoTransmissionCarCount = (int)auto.carCountByTranmissionIsAuto,
                KmSmallerThan1000CarCount = (int)km.carCountByKmSmallerThen1000,
                GasolineOrDieselCarCount = gas.carCountByFuelGasolineOrDiesel,
                ElectricCarCount = electric.carCountByFuelElectric,

                MaxDailyRentCar = maxRent.carBrandAndModeByRentPriceDailyMax,
                MinDailyRentCar = minRent.carBrandAndModeByRentPriceDailyMin,
                BrandWithMaxCar = brandMax.brandNameByMaxCar,
                BlogWithMaxComment = blogMax.blogTitleByMaxBlogComment
            };
        }
    }
}
