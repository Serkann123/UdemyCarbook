using UdemyCarbook.Domain.Entities;

namespace UdemyCarbook.Application.Interfaces.CarDescriptionInterfaces
{
    public interface ICarDescriptionRepository
    {
        Task<CarDescription> GetCarDescriptionAsync(int CarId);
    }
}
