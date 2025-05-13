using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Application.Users.Services.RefreshToken.Implementations.Exceptions;
using NouveauSellix.Application.Users.Services.RefreshToken.IO;
using NouveauSellix.Domain.Users.ValueObjects;

namespace NouveauSellix.Application.Users.Services.RefreshToken.Implementations
{
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IUserRepository _userRepository;

        public RefreshTokenService(IJwtHandler jwtHandler, IUserRepository userRepository)
        {
            _jwtHandler = jwtHandler;
            _userRepository = userRepository;
        }

        public async Task<RefreshTokenServiceOutput> ExecuteAsync(RefreshTokenServiceInput input)
        {
            var claims = _jwtHandler.IsAuthentic(input.OldToken);
            var claimEmail = (claims.FirstOrDefault(u => u.Type == "email"))?.Value;

            if (claimEmail == null)
                throw new InvalidJwtTokenException();

            var email = new EmailValueObject(claimEmail);
            var user = await _userRepository.SearchByEmailAsync(email);
            var newToken = _jwtHandler.GenerateToken(user);

            return new RefreshTokenServiceOutput
            {
                Message = "OK",
                Token = newToken,
                StatusCode = 200
            };
        }
    }
}
