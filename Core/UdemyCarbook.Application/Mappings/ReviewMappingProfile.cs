using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.ReviewCommands;
using UdemyCarbook.Application.Features.Mediator.Queries.ReviesQueries;
using UdemyCarbook.Application.Features.Mediator.Results.ReviewResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class ReviewMappingProfile : Profile
    {
        public ReviewMappingProfile()
        {
            CreateMap<Review, GetReviewByCarIdQuery>();

            CreateMap<CreateReviewCommand, Review>()
                .ForMember(dest => dest.ReviewDate,
                    opt => opt.MapFrom(s => DateTime.Parse(DateTime.Now.ToShortDateString())));

            CreateMap<UpdateReviewCommand, Review>()
                .ForMember(dest => dest.ReviewId, opt => opt.Ignore());

            CreateMap<Review, GetReviewByCarIdQueryResult>();
        }
    }
}
