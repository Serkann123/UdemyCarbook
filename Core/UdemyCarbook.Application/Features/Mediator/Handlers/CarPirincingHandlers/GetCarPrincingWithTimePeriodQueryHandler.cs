﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.CarPirincingQueries;
using UdemyCarbook.Application.Features.Mediator.Results.CarPirincingResults;
using UdemyCarbook.Application.Interfaces.CarPirincingInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.CarPirincingHandlers
{
    public class GetCarPrincingWithTimePeriodQueryHandler : IRequestHandler<GetCarPrincingWithTimePeriodQuery, List<GetCarPrincingWithTimePeriodQueryResult>>
    {
        private readonly ICarPirincingRepository _repository;

        public GetCarPrincingWithTimePeriodQueryHandler(ICarPirincingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarPrincingWithTimePeriodQueryResult>> Handle(GetCarPrincingWithTimePeriodQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarPricingWithTimePeriod();

            return values.Select(x => new GetCarPrincingWithTimePeriodQueryResult
            {
                Model = x.Model,
                BrandName = x.BrandName,
                ModelName = x.ModelName,
                DailyAmount = x.DailyAmount,
                WeeklyAmount = x.WeeklyAmount,
                MonthlyAmount = x.MonthlyAmount,
                CoverImageUrl = x.CoverImageUrl,
            }).ToList();
        }
    }
}
