using UdemyCarbook.Dto.LoginDtos;
using UdemyCarbook.WebUI.Models;

namespace UdemyCarbook.Application.Services
{
    public interface ILoginApiService
    {
        Task<JwtTokenDto?> LoginAsync(ResultLoginDto dto);
    }
}
