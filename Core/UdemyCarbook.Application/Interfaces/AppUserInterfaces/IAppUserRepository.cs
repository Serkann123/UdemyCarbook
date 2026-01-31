using System.Linq.Expressions;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.AppUserInterfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter);
    }
}
