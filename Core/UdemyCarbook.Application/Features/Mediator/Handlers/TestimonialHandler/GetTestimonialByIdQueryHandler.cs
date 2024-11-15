using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.TestimonialQueries;
using UdemyCarbook.Application.Features.Mediator.Results.TestimonialResults;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.TestimonialHandler
{
    public class GetTestimonialByIdQueryHandler:IRequestHandler<GetTestimonialByIdQuery,GetTestimonialByIdQıeryResult>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialByIdQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<GetTestimonialByIdQıeryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTestimonialByIdQıeryResult
            {
                Title=values.Title,
                Name=values.Name,
                Comment=values.Comment,
                ImageUrl=values.ImageUrl,
                TestimonialId=values.TestimonialId
            };
        }
    }
}
