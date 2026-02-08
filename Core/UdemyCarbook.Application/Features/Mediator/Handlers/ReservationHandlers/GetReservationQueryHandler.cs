using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.ReservationQueries;
using UdemyCarbook.Application.Features.Mediator.Results.ReservationResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;


namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetReservationQueryResult
            {
                ReservationId = x.ReservationId,
                Age = x.Age,
                CarId = x.CarId,
                Description = x.Description,
                DriverLicenseYear = x.DriverLicenseYear,
                DropOffLocationId = x.DropOffLocationId,
                Email = x.Email,
                Name = x.Name,
                Surname = x.Surname,
                Phone = x.Phone,
                PickUpLocationId = x.PickUpLocationId,
                Status = x.Status
            }).ToList();
        }
    }
}
