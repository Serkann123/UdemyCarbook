using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Dto.BrandDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IBrandApiService
    {
        Task<List<ResultBrandDto>> GetAllAsync();
        Task<UpdateBrandDto> GetByIdAsync(int id);
        Task<bool> CreateAsync(CreateBrandDto dto);
        Task<bool> UpdateAsync(UpdateBrandDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
