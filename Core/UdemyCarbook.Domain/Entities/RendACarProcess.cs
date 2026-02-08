namespace UdemyCarbook.Domain.Entities
{
    public class RendACarProcess
    {
        public int RendACarProcessId { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int PickUpLocationId { get; set; }
        public int DropOffLocationId { get; set; }

        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public TimeSpan PickUpTime { get; set; }
        public TimeSpan DropOffTime { get; set; }

        public string PickUpDescription { get; set; }
        public string DropOffLocationDescription { get; set; }

        public decimal TotalPrice { get; set; }
    }
}