using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.CommentResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.CommentQueires
{
    public class GetCommentListByBlogIdQuery:IRequest<List<GetCommentListByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetCommentListByBlogIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
