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

namespace UdemyCarbook.Application.Features.Mediator.Handlers.PirincingHandler
{
    internal class GetPirincingQueryHandler : IRequestHandler<GetPirincingQuery, List<GetPiricingQueryResult>>
    {
        private readonly IRepository<Piricing> _repository;
        public GetPirincingQueryHandler(IRepository<Piricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPiricingQueryResult>> Handle(GetPirincingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPiricingQueryResult
            {
               PricingId=x.PricingId,
               Name=x.Name
            }).ToList();
        }
    }
}
