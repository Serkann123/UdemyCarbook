using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Dto.CarDtos;
using UdemyCarbook.Dto.CarPirincingDtos;

namespace UdemyCarbook.Application.Services
{
    public interface ICarApiService
    {
        Task<List<ResultCarWithBrandDto>> GetAllAsync();
        Task<UpdateCarDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateCarDto dto);
        Task<bool> UpdateAsync(UpdateCarDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
