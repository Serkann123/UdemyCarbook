using UdemyCarbook.Dto.CarDescriptionDtos;
using UdemyCarbook.Dto.CarDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ICarApiService
    {
        Task<List<ResultCarWithBrandDto>> GetAllAsync();
        Task<UpdateCarDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCarDto dto);
        Task<bool> UpdateAsync(UpdateCarDto dto);
        Task<bool> RemoveAsync(int id);
        Task<List<ResultCarForReservationDto>> GetCarWithBrandAsync();
        Task<List<ResultLast5CarsWithBrandDto>> GetLast5CarsWithBrandAsync();
        Task<ResultCarDescriptionByCarIdDto?> GetDescriptionByCarIdAsync(int carId);
        Task<ResultCarMainCarFeatureDto?> GetMainCarFeatureAsync(int carId);
    }
}
