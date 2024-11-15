using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.CarPirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.CarPirincingResults;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarPirincingHandler
{
    public class GetCarPİrincingQueryHandler:IRequestHandler<GetCarPirincingQuery,List<GetCarPirincingQueryResult>>
    {
        private readonly ICarPirincing _pirincing;

        public GetCarPİrincingQueryHandler(ICarPirincing pirincing)
        {
            _pirincing = pirincing;
        }

        public Task<List<GetCarPirincingQueryResult>> Handle(GetCarPirincingQuery request, CancellationToken cancellationToken)
        {
            var values = _pirincing.GetCarPirincingWihCars();
            throw new NotImplementedException();
        }
    }
}
