using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.ReviesQueries;
using UdemyCarbook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarbook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;

        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _reviewRepository.GetReviewByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResult
            {
                CarId = x.CarId,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RaytingValue = x.RaytingValue,
                ReviewId = x.ReviewId,
                ReviewDate = x.ReviewDate,
            }).ToList();
        }
    }
}
