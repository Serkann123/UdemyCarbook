using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.AppUserInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly CarbookContext _carbookContext;

        public AppUserRepository(CarbookContext carbookContext)
        {
            _carbookContext = carbookContext;
        }

        public async Task<AppUser?> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            return await _carbookContext.AppUsers.FirstOrDefaultAsync(filter);
        }
    }
}
