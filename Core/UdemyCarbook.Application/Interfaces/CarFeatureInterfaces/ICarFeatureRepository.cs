using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeatureByCarId(int carId);
        void ChangeCarFeaturesAvailableToFalse(int id);
        void ChangeCarFeaturesAvailableToTrue(int id);
    }
}
