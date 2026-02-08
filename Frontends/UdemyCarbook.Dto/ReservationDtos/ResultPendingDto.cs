
namespace UdemyCarbook.Dto.ReservationDtos
{
    public class ResultPendingDto
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CarId { get; set; }
        public string CarName { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public string Status { get; set; }
    }
}
