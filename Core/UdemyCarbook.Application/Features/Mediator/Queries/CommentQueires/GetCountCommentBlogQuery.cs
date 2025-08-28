using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.CommentResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.CommentQueires
{
    public class GetCountCommentBlogQuery:IRequest<GetCountCommentBlogQueryResult>
    {
        public GetCountCommentBlogQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
