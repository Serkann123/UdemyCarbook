using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarbook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarbook.Application.Interfaces.AppRolesInterfaces;
using UdemyCarbook.Application.Interfaces.AppUserInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.AppUserHandler
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserResult>
    {
        readonly IAppUserRepository _appUserRepository;
        readonly IAppRoleRepository _appRoleRepository;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IAppRoleRepository appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            GetCheckAppUserResult values = new();
            var user = await _appUserRepository.GetByFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                values.IsExist = false;
            }

            else
            {
                values.IsExist = true;
                values.UserName = user.UserName;
                values.AppUserId = user.AppUserId;
                values.Role = (await _appRoleRepository.GetByFilterAsync(x => x.AppRoleId == user.AppRoleId))?.Name;
            }
            return values;
        }
    }
}
