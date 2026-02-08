namespace UdemyCarbook.Dto.StatisticsDtos
{
    public class GetDashboardDto
    {
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
    }
}
