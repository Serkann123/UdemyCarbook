using MediatR;
using UdemyCarbook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public UpdateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ReservationId);

            values.Age = request.Age;
            values.CarId = request.CarId;
            values.Description = request.Description;
            values.DriverLicenseYear = request.DriverLicenseYear;
            values.DropOffLocationId = request.DropOffLocationId;
            values.Email = request.Email;
            values.Name = request.Name;
            values.Surname = request.Surname;
            values.Phone = request.Phone;
            values.PickUpLocationId = request.PickUpLocationId;
            values.Status = "Rezervasyon Alındı";

            await _repository.UpdateAsync(values);
        }
    }
}
