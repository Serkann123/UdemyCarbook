using UdemyCarbook.WebUI.Models;

namespace UdemyCarbook.WebUI.Extensions
{
    public static class AdminStatisticsUiExtensions
    {
        public static void PrepareStatGroups(this AdminStatisticsVm vm)
        {
            // 1. GRUP: Temel İstatistikler
            vm.MainStats = new List<StatCardItem>
            {
                new StatCardItem { Title = "Toplam Araç Sayısı", Value = vm.CarCount.ToString(), Icon = "fa-solid fa-car", Theme = "primary", Rate = vm.CarCountRandom, Desc = "Artış oranı", IsUp = true },
                new StatCardItem { Title = "Lokasyon Sayısı", Value = vm.LocationCount.ToString(), Icon = "fa-solid fa-map-location-dot", Theme = "success", Rate = vm.LocationCountRandom, Desc = "Doluluk", IsUp = false },
                new StatCardItem { Title = "Personel Sayısı", Value = vm.AuthorCount.ToString(), Icon = "fa-solid fa-users", Theme = "warning", Rate = vm.AuthorCountRandom, Desc = "Aktif", IsUp = true },
                new StatCardItem { Title = "Blog Sayısı", Value = vm.BlogCount.ToString(), Icon = "fa-brands fa-blogger-b", Theme = "info", Rate = vm.BlogCountRandom, Desc = "İçerik", IsUp = true }
            };

            // 2. GRUP: Fiyat Analizi
            vm.PriceStats = new List<StatCardItem>
            {
                new StatCardItem { Title = "Ort. Günlük", Value = vm.AvgRentPriceDaily.ToString("N2") + " ₺", Icon = "fa-solid fa-calendar-day", Theme = "success", Rate = vm.AvgDailyRandom },
                new StatCardItem { Title = "Ort. Haftalık", Value = vm.AvgRentPriceWeekly.ToString("N2") + " ₺", Icon = "fa-solid fa-calendar-week", Theme = "warning", Rate = vm.AvgWeeklyRandom },
                new StatCardItem { Title = "Ort. Aylık", Value = vm.AvgRentPriceMonthly.ToString("N2") + " ₺", Icon = "fa-regular fa-calendar-days", Theme = "info", Rate = vm.AvgMonthlyRandom }
            };

            // 3. GRUP: Araç Durumları
            vm.VehicleStats = new List<StatCardItem>
            {
                new StatCardItem { Title = "Otomatik Vites", Value = vm.AutoTransmissionCarCount.ToString(), Icon = "fa-solid fa-gears", Theme = "primary" },
                new StatCardItem { Title = "Benzin & Dizel", Value = vm.GasolineOrDieselCarCount.ToString(), Icon = "fa-solid fa-gas-pump", Theme = "danger" },
                new StatCardItem { Title = "Elektrikli Araç", Value = vm.ElectricCarCount.ToString(), Icon = "fa-solid fa-charging-station", Theme = "success" },
                new StatCardItem { Title = "Aktif Marka", Value = vm.BrandCount.ToString(), Icon = "fa-solid fa-copyright", Theme = "info" }
            };
        }
    }
}