using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarbook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarbook.Application.Tools;

namespace UdemyCarbook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        readonly IMediator _meditor;
        readonly IConfiguration _configuration;

        public LoginController(IMediator meditor, IConfiguration configuration)
        {
            _meditor = meditor;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(GetCheckAppUserQuery query)
        {
            JwtTokenGenarator jwtTokenGenarator = new JwtTokenGenarator(_configuration);
            var values = await _meditor.Send(query);
            if (values.IsExist)
            {
                return Created("", jwtTokenGenarator.GenerateToken(values));
            }
            else
            {
                return BadRequest("Kullancı adı veya şifre hatalıdır");
            }
        }
    }
}
