using MediatR;

namespace UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands
{
    public class UpdateReservationCommand : IRequest
    {
        public int ReservationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? PickUpLocationId { get; set; }
        public int? DropOffLocationId { get; set; }
        public DateTime PickUpDateTime { get; set; }
        public DateTime DropOffDateTime { get; set; }
        public int CarId { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
