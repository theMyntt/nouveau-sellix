using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Application.Users.Services.UpdateUserImage.IO;
using NouveauSellix.Domain.Users.ValueObjects;

namespace NouveauSellix.Application.Users.Services.UpdateUserImage.Implementations
{
    public class UpdateUserImageService : IUpdateUserImageService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFileManager _userFileManager;

        public UpdateUserImageService(IUserRepository userRepository, IUserFileManager userFileManager)
        {
            _userRepository = userRepository;
            _userFileManager = userFileManager;
        }

        public async Task ExecuteAsync(UpdateUserImageServiceInput input)
        {
            var email = new EmailValueObject(input.Email);
            var user = await _userRepository.SearchByEmailAsync(email);

            if (user.ImagePath != null)
            {
                _userFileManager.DeleteFile(user.ImagePath);
            }

            using var stream = new MemoryStream();
            await input.Image.CopyToAsync(stream);

            var path = await _userFileManager.SaveNewProfilePictureAsync(stream.ToArray());

            await _userRepository.UpdateUserImage(user, path);
        }
    }
}
