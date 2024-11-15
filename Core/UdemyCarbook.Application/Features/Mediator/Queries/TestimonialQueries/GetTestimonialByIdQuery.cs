using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.TestimonialResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQıeryResult>
    {
        public int Id { get; set; }

        public GetTestimonialByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
