using System.Linq.Expressions;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.AppRolesInterfaces
{
    public interface IAppRoleRepository
    {
        Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter);
    }
}
