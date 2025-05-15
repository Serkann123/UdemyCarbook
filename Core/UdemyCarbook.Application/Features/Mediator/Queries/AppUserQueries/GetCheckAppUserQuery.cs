using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Results.AppUserResults;

namespace UdemyCarbook.Application.Features.Mediator.Queries.AppUserQueries
{
    public class GetCheckAppUserQuery:IRequest<GetCheckAppUserResult>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
