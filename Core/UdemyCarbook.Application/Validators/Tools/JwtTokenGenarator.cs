using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyCarbook.Application.Dtos;
using UdemyCarbook.Application.Features.Mediator.Results.AppUserResults;

namespace UdemyCarbook.Application.Validators.Tools
{
    public class JwtTokenGenarator
    {
        readonly IConfiguration _configuration;

        public JwtTokenGenarator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TokenResponseDto GenerateToken(GetCheckAppUserResult result)
        {
            List<Claim> claims = new();

            if (!string.IsNullOrWhiteSpace(result.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, result.Role));
            }

            claims.Add(new Claim(ClaimTypes.NameIdentifier, result.AppUserId.ToString()));

            if (!string.IsNullOrWhiteSpace(result.UserName))
            {
                claims.Add(new Claim("Username", result.UserName));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddDays(int.Parse(_configuration["Token:Expire"]));

            JwtSecurityToken token = new JwtSecurityToken(

                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expireDate,
                signingCredentials: signinCredentials
            );

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
        }
    }
}
