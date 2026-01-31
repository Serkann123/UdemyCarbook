using System.Linq.Expressions;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.RentACarInterfaces
{
    public interface IRentACarRepository
    {
       Task<List<RendACar>> GetByFilterAsync(Expression<Func<RendACar, bool>> filter);
    }
}
