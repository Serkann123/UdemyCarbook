using UdemyCarbook.Dto.RegisterDtos;

namespace UdemyCarbook.Application.Services
{
    public interface IRegisterApiService
    {
        Task<bool> CreateUserAsync(CreateRegisterDto dto);
    }
}
