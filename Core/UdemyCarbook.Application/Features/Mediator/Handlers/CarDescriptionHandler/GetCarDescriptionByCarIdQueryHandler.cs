using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.CarDescriptionQueires;
using UdemyCarbook.Application.Features.Mediator.Results.CarDescriptionResults;
using UdemyCarbook.Application.Interfaces.CarDescriptionInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarDescriptionHandler
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionQueryResult>
    {
        private readonly ICarDescriptionInterfaces _repository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionInterfaces repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarDescription(request.Id);

            if (values == null)
            {
                return new GetCarDescriptionQueryResult
                {
                    CarDescriptionId = 0,
                    CarId = request.Id,
                    Details = "Açıklama bulunamadı."
                };
            }

            return new GetCarDescriptionQueryResult
            {
                CarDescriptionId = values.CarDescriptionId,
                CarId = values.CarId,
                Details = values.Details,
            };
        }
    }
}
