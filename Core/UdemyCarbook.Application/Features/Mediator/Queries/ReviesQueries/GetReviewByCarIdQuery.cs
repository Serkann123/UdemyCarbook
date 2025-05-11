using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.ReviewResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.ReviesQueries
{
    public class GetReviewByCarIdQuery:IRequest<List<GetReviewByCarIdQueryResult>>
    {
        public int Id { get; set; }
        public GetReviewByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}
