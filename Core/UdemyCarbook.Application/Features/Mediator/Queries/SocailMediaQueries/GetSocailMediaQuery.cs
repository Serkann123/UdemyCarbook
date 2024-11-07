using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.SocialMediaResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.SocailMediaQueries
{
    public class GetSocailMediaQuery:IRequest<List<GetSocialMediaQueryResult>>
    {
    }
}
