using AutoMapper;
using MediatR;
using UdemyCarbook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarbook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarbook.Application.Interfaces.AppRolesInterfaces;
using UdemyCarbook.Application.Interfaces.AppUserInterfaces;

namespace UdemyCarbook.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserResult>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IAppRoleRepository _appRoleRepository;
        private readonly IMapper _mapper;

        public GetCheckAppUserQueryHandler(IAppUserRepository appUserRepository, IAppRoleRepository appRoleRepository,IMapper mapper)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
            _mapper = mapper;
        }

        public async Task<GetCheckAppUserResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserResult();
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
