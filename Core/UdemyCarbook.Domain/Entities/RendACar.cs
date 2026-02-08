namespace UdemyCarbook.Domain.Entities
{
    public class RendACar
    {
        public int RendACarId { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public bool Available { get; set; }
    }
}
