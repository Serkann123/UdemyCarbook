using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UdemyCarbook.Application.Interfaces.AppRolesInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.AppRoleRepositories
{
    public class AppRoleRepositories : IAppRoleRepository
    {
        private readonly CarbookContext _context;

        public AppRoleRepositories(CarbookContext context)
        {
            _context = context;
        }

        public async Task<AppRole?> GetByFilterAsync(Expression<Func<AppRole, bool>> filter)
        {
            return await _context.AppRoles.FirstOrDefaultAsync(filter);
        }
    }
}
