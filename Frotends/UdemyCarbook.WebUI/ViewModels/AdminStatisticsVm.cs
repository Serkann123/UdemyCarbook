namespace UdemyCarbook.WebUI.ViewModels
{
    public class AdminStatisticsVm
    {
        // Sayılar
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }

        // Ortalama fiyatlar
        public decimal AvgRentPriceDaily { get; set; }
        public decimal AvgRentPriceWeekly { get; set; }
        public decimal AvgRentPriceMonthly { get; set; }

        // Araç istatistikleri
        public int AutoTransmissionCarCount { get; set; }
        public int KmSmallerThan1000CarCount { get; set; }
        public int GasolineOrDieselCarCount { get; set; }
        public int ElectricCarCount { get; set; }

        // Metinsel bilgiler
        public string? MaxDailyRentCar { get; set; }
        public string? MinDailyRentCar { get; set; }
        public string? BrandWithMaxCar { get; set; }
        public string? BlogWithMaxComment { get; set; }

        // Random (UI için)
        public int CarCountRandom { get; set; }
        public int LocationCountRandom { get; set; }
        public int BlogCountRandom { get; set; }
        public int AuthorCountRandom { get; set; }
        public int BrandCountRandom { get; set; }

        public int AvgDailyRandom { get; set; }
        public int AvgWeeklyRandom { get; set; }
        public int AvgMonthlyRandom { get; set; }

        public int AutoTransmissionRandom { get; set; }
        public int KmSmallerThan1000Random { get; set; }
        public int GasolineOrDieselRandom { get; set; }
        public int ElectricRandom { get; set; }

        public int MaxDailyRentCarRandom { get; set; }
        public int MinDailyRentCarRandom { get; set; }
        public int BrandWithMaxCarRandom { get; set; }
        public int BlogWithMaxCommentRandom { get; set; }
    }
}
