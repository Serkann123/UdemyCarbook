using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Interfaces;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CarbookContext c;

        public Repository(CarbookContext context)
        {
            c = context;
        }

        public async Task CreateAsync(T Entity)
        {
            c.Set<T>().Add(Entity);
            await c.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await c.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await c.Set<T>().FindAsync(id);
        }

        public async Task RemoveAync(T Entity)
        {
            c.Set<T>().Remove(Entity);
            await c.SaveChangesAsync();
        }

        public async Task UpdateAsync(T Entity)
        {
            c.Set<T>().Update(Entity);
            await c.SaveChangesAsync();
        }
    }
}
