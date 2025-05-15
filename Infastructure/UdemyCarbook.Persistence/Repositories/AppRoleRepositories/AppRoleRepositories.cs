using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyCarbook.Application.Interfaces.AppRolesInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.AppRoleRepositories
{
    public class AppRoleRepositories : IAppRoleRepository
    {
        readonly CarbookContext _context;

        public AppRoleRepositories(CarbookContext context)
        {
            _context = context;
        }

        public async Task<AppRole> GetByFilterAsync(Expression<Func<AppRole, bool>> filter)
        {
            var value = await _context.AppRoles.Where(filter).FirstOrDefaultAsync();
            return value;
        }
    }
}
