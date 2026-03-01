using AutoMapper;
using UdemyCarbook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarbook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Mappings
{
    public class TestimonialMappingProfile : Profile
    {
        public TestimonialMappingProfile()
        {
            CreateMap<Testimonial, GetTestimonialQueryResult>();
            CreateMap<Testimonial, GetTestimonialByIdQıeryResult>();
            CreateMap<CreateTestimonialCommand, Testimonial>();
            CreateMap<UpdateTestimonialCommand, Testimonial>()
                .ForMember(dest => dest.TestimonialId, opt => opt.Ignore());
        }
    }
}
