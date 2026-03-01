using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.ReviesQueries;
using UdemyCarbook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarbook.Application.Interfaces.ReviewInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public GetReviewByCarIdQueryHandler(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _reviewRepository.GetReviewByCarIdAsync(request.Id);
            return _mapper.Map<List<GetReviewByCarIdQueryResult>>(values);
        }
    }
}