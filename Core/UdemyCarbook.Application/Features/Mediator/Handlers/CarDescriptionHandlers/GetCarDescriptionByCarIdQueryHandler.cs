using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.CarDescriptionQueires;
using UdemyCarbook.Application.Features.Mediator.Results.CarDescriptionResults;
using UdemyCarbook.Application.Interfaces.CarDescriptionInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionQueryResult>
    {
        private readonly ICarDescriptionRepository _repository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetCarDescriptionAsync(request.Id);

            if (entity is null)
            {
                return new GetCarDescriptionQueryResult
                {
                    CarId = request.Id,
                    Details = "Açıklama bulunamadı."
                };
            }

            return new GetCarDescriptionQueryResult
            {
                CarDescriptionId = entity.CarDescriptionId,
                CarId = entity.CarId,
                Details = entity.Details,
            };
        }
    }
}
