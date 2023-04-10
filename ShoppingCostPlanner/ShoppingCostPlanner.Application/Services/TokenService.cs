using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCostPlanner.Application.Interfaces.Service;
using ShoppingCostPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var userId = user.Id.ToString();
            var email = user.Email.ToString();
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Email, email)
        };

            // Let's say user has some roles -> we add those roles to their claims
            var roles = new List<string> { "Admin", "User", "HR" };
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            // The secret key used to sign the access token
            var secretKey = _configuration.GetSection("Jwt").GetValue<string>("Secret");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var guid = Guid.NewGuid();
            return guid.ToString().Replace("-", "");
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                // You might want to validate audience and issuer, but for demo purposes let's leave them disabled
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt").GetValue<string>("Secret"))),
                ValidateLifetime = false // We expect the token to be expired
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            // This will throw an exception if the token is not valid
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out _);

            return principal;
        }
    }
}
