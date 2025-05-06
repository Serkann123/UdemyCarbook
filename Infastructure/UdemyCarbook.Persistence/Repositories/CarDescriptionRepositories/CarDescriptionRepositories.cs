using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarbook.Domain.Entities;
using UdemyCarbook.Persistence.Context;

namespace UdemyCarbook.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepositories : ICarDescriptionInterfaces
    {
        private readonly CarbookContext _context;

        public CarDescriptionRepositories(CarbookContext context)
        {
            _context = context;
        }

        public CarDescription GetCarDescription(int CarId)
        {
            var values = _context.CarDescriptions.Where(x => x.CarId == CarId).FirstOrDefault();
            return values;
        }
    }
}
