using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Interfaces.RentACarInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository:IRentACarRepository
    {
        private readonly CarbookContext _carbookContext;

        public RentACarRepository(CarbookContext carbookContext)
        {
            _carbookContext = carbookContext;
        }

        public async Task<List<RendACar>> GetByFilterAsync(Expression<Func<RendACar, bool>> filter)
        {
            var value =await _carbookContext.RendACars.Where(filter).ToListAsync();
            return value.ToList();
        }
    }
}
