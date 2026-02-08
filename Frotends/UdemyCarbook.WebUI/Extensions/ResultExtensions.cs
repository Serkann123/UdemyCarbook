using UdemyCarbook.Dto.StatisticsDtos;
using System.Reflection;
using UdemyCarbook.WebUI.ViewModels;

namespace UdemyCarbook.WebUI.Extensions
{
    public static class ResultExtensions
    {
        public static AdminStatisticsVm ToAdminStatisticsVm(this GetDashboardDto dto)
        {
            // 1. Verileri Aktar
            var vm = new AdminStatisticsVm
            {
                CarCount = dto.CarCount,
                LocationCount = dto.LocationCount,
                AuthorCount = dto.AuthorCount,
                BlogCount = dto.BlogCount,
                BrandCount = dto.BrandCount,

                AvgRentPriceDaily = dto.AvgRentPriceDaily,
                AvgRentPriceWeekly = dto.AvgRentPriceWeekly,
                AvgRentPriceMonthly = dto.AvgRentPriceMonthly,

                AutoTransmissionCarCount = dto.AutoTransmissionCarCount,
                KmSmallerThan1000CarCount = dto.KmSmallerThan1000CarCount,
                GasolineOrDieselCarCount = dto.GasolineOrDieselCarCount,
                ElectricCarCount = dto.ElectricCarCount,

                MaxDailyRentCar = dto.MaxDailyRentCar,
                MinDailyRentCar = dto.MinDailyRentCar,
                BrandWithMaxCar = dto.BrandWithMaxCar,
                BlogWithMaxComment = dto.BlogWithMaxComment
            };

            // 2. Random Değerleri Otomatik Doldur (Reflection ile)
            // Sonu "Random" ile biten tüm property'leri bulur ve 0-100 arası sayı basar.
            // O kadar satır kodu tek döngüye indirdik.
            var random = new Random();
            foreach (var prop in typeof(AdminStatisticsVm).GetProperties())
            {
                if (prop.Name.EndsWith("Random") && prop.PropertyType == typeof(int))
                {
                    prop.SetValue(vm, random.Next(0, 101));
                }
            }
            return vm;
        }
    }
}