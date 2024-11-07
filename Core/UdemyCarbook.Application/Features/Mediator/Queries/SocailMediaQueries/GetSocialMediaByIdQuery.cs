using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.SocialMediaResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.SocailMediaQueries
{
    public class GetSocialMediaByIdQuery:IRequest<GetSocialMediaByIdQueyResult>
    {
        public int Id { get; set; }

        public GetSocialMediaByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}
