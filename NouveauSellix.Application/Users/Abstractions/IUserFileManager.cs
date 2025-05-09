using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NouveauSellix.Application.Users.Abstractions
{
    public interface IUserFileManager
    {
        Task<string> SaveNewProfilePictureAsync(byte[] photo);
    }
}
