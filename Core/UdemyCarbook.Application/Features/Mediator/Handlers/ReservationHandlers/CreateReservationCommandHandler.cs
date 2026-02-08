using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                Phone = request.Phone,
                PickUpLocationId = request.PickUpLocationId,
                DropOffLocationId = request.DropOffLocationId,
                CarId = request.CarId,
                PickUpDateTime = request.PickUpDateTime,
                DropOffDateTime = request.DropOffDateTime,
                Age = request.Age,
                DriverLicenseYear = request.DriverLicenseYear,
                Description = request.Description,
                Status = "Pending"
            });
        }
    }
}