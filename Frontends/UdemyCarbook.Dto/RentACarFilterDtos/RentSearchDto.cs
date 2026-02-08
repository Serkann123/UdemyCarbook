using UdemyCarbook.Dto.RentACarFilterDtos;

namespace UdemyCarbook.WebUI.ViewModels
{
    public class RentSearchDto
    {
        public int LocationId { get; set; }
        public DateTime PickUp { get; set; }
        public DateTime DropOff { get; set; }
    }
}
