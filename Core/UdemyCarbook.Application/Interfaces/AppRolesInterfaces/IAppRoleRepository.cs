using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.AppRolesInterfaces
{
    public interface IAppRoleRepository
    {
        Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter);
    }
}
