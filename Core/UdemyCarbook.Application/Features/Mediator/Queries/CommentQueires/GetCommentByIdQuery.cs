using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.CommentResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.CommentQueires
{
    public class GetCommentByIdQuery:IRequest<GetCommentByIdQueryResult>
    {
        public int Id { get; set; }
        public GetCommentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
