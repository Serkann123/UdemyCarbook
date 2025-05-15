using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);
    }
}
