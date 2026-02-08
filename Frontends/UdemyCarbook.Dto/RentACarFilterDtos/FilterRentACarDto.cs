namespace UdemyCarbook.Dto.RentACarFilterDtos
{
    public class FilterRentACarDto
    {
        public int CarId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Amount { get; set; }
        public string Transmission { get; set; }
        public string Fuel { get; set; }
        public int Seat { get; set; }
    }
}
