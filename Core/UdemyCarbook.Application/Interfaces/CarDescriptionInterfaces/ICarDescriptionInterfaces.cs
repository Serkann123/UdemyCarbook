using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionInterfaces
    {
        CarDescription GetCarDescription(int CarId);
    }
}
