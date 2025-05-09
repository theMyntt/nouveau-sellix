using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Application.Users.Services.Login.IO;
using NouveauSellix.Domain.Users.ValueObjects;

namespace NouveauSellix.Application.Users.Services.Login.Implementations
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtHandler _jwtHandler;

        public LoginService(IUserRepository userRepository, IJwtHandler jwtHandler)
        {
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
        }

        public async Task<LoginServiceOutput> ExecuteAsync(LoginServiceInput input)
        {
            var email = new EmailValueObject(input.Email);
            var user = await _userRepository.SearchByEmailAsync(email);
            
            if (user == null)
                throw new Exception();

            var isNotEqualPassword = !(user.Password.MatchesWith(input.Password));

            if (isNotEqualPassword)
                throw new Exception();

            var token = _jwtHandler.GenerateToken(user);

            return new LoginServiceOutput
            {
                Message = "OK",
                Token = token,
                StatusCode = 200
            };
        }
    }
}
