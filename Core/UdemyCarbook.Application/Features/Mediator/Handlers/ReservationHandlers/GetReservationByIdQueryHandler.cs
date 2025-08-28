using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.ReservationQueries;
using UdemyCarbook.Application.Features.Mediator.Results.FooterAddressResults;
using UdemyCarbook.Application.Features.Mediator.Results.ReservationResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;


namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationByIdQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetReservationByIdQueryResult
            {
                ReservationId = values.ReservationId,
                Age = values.Age,
                CarId = values.CarId,
                Description = values.Description,
                DriverLicenseYear = values.DriverLicenseYear,
                DropOffLocationId = values.DropOffLocationId,
                Email = values.Email,
                Name = values.Name,
                Surname = values.Surname,
                Phone = values.Phone,
                PickUpLocationId = values.PickUpLocationId,
                Status = "Rezervasyon Alındı"
            };
        }
    }
}
