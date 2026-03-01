using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.ReservationQueries;
using UdemyCarbook.Application.Features.Mediator.Results.ReservationResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;


namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IMapper _mapper;
        public GetReservationByIdQueryHandler(IRepository<Reservation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GetReservationByIdQueryResult>(entity);
        }
    }
}
