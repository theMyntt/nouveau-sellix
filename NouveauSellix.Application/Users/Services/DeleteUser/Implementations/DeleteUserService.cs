using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Application.Users.Services.DeleteUser.IO;
using NouveauSellix.Application.Users.Services.RefreshToken.Implementations.Exceptions;
using NouveauSellix.Domain.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NouveauSellix.Application.Users.Services.DeleteUser.Implementations
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IUserRepository _repository;
        private readonly IJwtHandler _jwtHandler;

        public DeleteUserService(IUserRepository repository, IJwtHandler jwtHandler)
        {
            _repository = repository;
            _jwtHandler = jwtHandler;
        }

        public async Task ExecuteAsync(DeleteUserServiceInput input)
        {
            var tokenClaims = _jwtHandler.IsAuthentic(input.Token);
            var claimEmail = (tokenClaims.FirstOrDefault(u => u.Type == "email"))?.Value;

            if (claimEmail == null)
                throw new InvalidJwtTokenException();

            var email = new EmailValueObject(claimEmail);

            await _repository.DeleteUserAsync(email);
        }
    }
}
