using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using UdemyCarbook.Application.Services;
using UdemyCarbook.Dto.LoginDtos;

namespace UdemyCarbook.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginApiService _loginApiService;

        public LoginController(ILoginApiService loginApiService)
        {
            _loginApiService = loginApiService;
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpPost]
        public async Task<IActionResult> Index(ResultLoginDto dto)
        {
            var tokenDto = await _loginApiService.LoginAsync(dto);

            if (tokenDto?.Token == null)
                return View();

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(tokenDto.Token);

            var claims = jwt.Claims.ToList();
            claims.Add(new Claim("accessToken", tokenDto.Token));

            var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                JwtBearerDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties
                {
                    ExpiresUtc = tokenDto.ExpireDate,
                    IsPersistent = true
                }
            );

            return RedirectToAction("Index", "AdminDashboard", new { area = "Admin" });
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
