namespace UdemyCarbook.Dto.ReservationDtos
{
    public class ReservationInputDto
    {
        public int CarId { get; set; }
        public int LocationId { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime DropOff { get; set; }
    }
}
