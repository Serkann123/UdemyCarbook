using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UdemyCarbook.Application.Interfaces.AppUserInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        readonly CarbookContext _carbookContext;

        public AppUserRepository(CarbookContext carbookContext)
        {
            _carbookContext = carbookContext;
        }

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            var name = filter;
            var value = await _carbookContext.AppUsers.Where(filter).FirstOrDefaultAsync();
            return value;
        }
    }
}
