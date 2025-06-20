using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Tea.Api.Data.JWT
{
    public static class JwtExtensions
    {
        static readonly IConfiguration _config;
        static readonly IConfiguration config = new ConfigurationBuilder()
                   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false).Build();

        static JwtExtensions()
        {
            _config = config;
        }
        public static JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var _configuration = config.GetSection("JWT");
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["ValidIssuer"],
                audience: _configuration["ValidAudience"],
                expires: DateTime.Now.AddMinutes(10),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
