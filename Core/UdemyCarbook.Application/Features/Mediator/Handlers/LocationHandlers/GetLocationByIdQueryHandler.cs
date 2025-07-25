﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.LocationQueires;
using UdemyCarbook.Application.Features.Mediator.Results.LocationResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.LocationHandlers
{
    public class GetLocationByIdQueryHandler:IRequestHandler<GetLocationByIdQuery,GetLocationByIdQueryResult>
    {
        private readonly IRepository<Location> _repository;
        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResult
            {
               LocationId=values.LocationId,
               Name=values.Name
            };
        }
    }
}
