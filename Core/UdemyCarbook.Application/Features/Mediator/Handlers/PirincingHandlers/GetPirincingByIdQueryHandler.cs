using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.PirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.PiricingResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.PirincingHandlers
{
    public class GetPirincingByIDQueryHandler : IRequestHandler<GetPirincingByIdQuery, GetPirincingByIdQueryResult>
    {
        private readonly IRepository<Piricing> _repository;

        public GetPirincingByIDQueryHandler(IRepository<Piricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPirincingByIdQueryResult> Handle(GetPirincingByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetPirincingByIdQueryResult
            {
                PricingId = values.PricingId,
                Name = values.Name
            };
        }
    }
}
