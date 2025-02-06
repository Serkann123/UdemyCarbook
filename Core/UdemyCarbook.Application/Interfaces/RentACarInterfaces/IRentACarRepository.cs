using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
       Task<List<RendACar>> GetByFilterAsync(Expression<Func<RendACar, bool>> filter);
    }
}
