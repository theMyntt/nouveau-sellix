using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Server;
using NouveauSellix.Application.Users.Abstractions;

namespace NouveauSellix.Infrastructure.Users.Handlers
{
    public class UserFileManager : IUserFileManager
    {
        private readonly string _imageFolderPath;

        public UserFileManager(IConfiguration configuration)
        {
            _imageFolderPath = configuration["ImageFolderPath"] ?? throw new Exception("ImageFolderPath Is Null On Settings");
        }

        public void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public async Task<string> SaveNewProfilePictureAsync(byte[] photo)
        {
            if (photo.Length == 0)
                return string.Empty;

            var folderCombination = $"Users/{DateTime.UtcNow.Year}/{DateTime.UtcNow.Month}/{DateTime.UtcNow.Day}";
            var folderPath = Path.Combine(_imageFolderPath, folderCombination);
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = Guid.NewGuid().ToString().Replace("-", "") + ".png";
            var filePath = Path.Combine(folderPath, fileName);

            await File.WriteAllBytesAsync(filePath, photo);

            return $"{folderCombination}/{fileName}";
        }
    }
}
