using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Application.Users.Services.CreateUser.IO;
using NouveauSellix.Domain.Users.Entities;
using NouveauSellix.Domain.Users.ValueObjects;

namespace NouveauSellix.Application.Users.Services.CreateUser.Implementations
{
    public class CreateUserService : ICreateUserService
    {
        private readonly IUserFileManager _userFileManager;
        private readonly IUserRepository _userRepository;

        public CreateUserService(IUserFileManager userFileManager, IUserRepository userRepository)
        {
            _userFileManager = userFileManager;
            _userRepository = userRepository;
        }

        public async Task<CreateUserServiceOutput> ExecuteAsync(CreateUserServiceInput input)
        {
            var password = new PasswordValueObject(input.Password);
            var email = new EmailValueObject(input.Email);
            var user = new UserEntity(
                name: input.Name,
                email: email,
                password: password,
                isBlocked: false,
                DateTime.UtcNow);

            if (input.Image != null)
            {
                using var stream = new MemoryStream();
                await input.Image.CopyToAsync(stream);
                
                var path = await _userFileManager.SaveNewProfilePictureAsync(stream.ToArray());

                user.WithImage(path);
            }

            await _userRepository.SaveUserAsync(user);

            return new CreateUserServiceOutput
            {
                Message = "Criado com sucesso.",
                User = user,
                StatusCode = 201
            };
        }
    }
}
