using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Domain.Users.Entities;
using NouveauSellix.Infrastructure.Users.Handlers.Exceptions;

namespace NouveauSellix.Infrastructure.Users.Handlers
{
    public class JwtHandler : IJwtHandler
    {
        private readonly SigningCredentials _credentials;
        private readonly IConfigurationSection _jwtSection;
        private readonly SymmetricSecurityKey _key;

        public JwtHandler(IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection("Jwt");
            _jwtSection = jwtSection;

            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSection["SecretKey"]!));
            _credentials = new(_key, SecurityAlgorithms.HmacSha256);
        }

        public string GenerateToken(UserEntity user)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var claims = new List<Claim>()
            {
                new(JwtRegisteredClaimNames.Email, user.Email.Value),
                new(JwtRegisteredClaimNames.Name, user.Name)
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSection["Issuer"]!,
                audience: _jwtSection["Audience"]!,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(2),
                signingCredentials: _credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public List<Claim> IsAuthentic(string token)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = false,
                IssuerSigningKey = _key,
                ValidIssuer = _jwtSection["Issuer"]!,
                ValidAudience = _jwtSection["Audience"]!,
                RequireSignedTokens = true,
                RequireExpirationTime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtToken || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new UnAuthenticJwtTokenException();

            return principal.Claims.ToList();
        }
    }
}
