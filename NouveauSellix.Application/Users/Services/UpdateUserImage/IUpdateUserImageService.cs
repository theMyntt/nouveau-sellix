using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Application.Users.Services.UpdateUserImage.IO;

namespace NouveauSellix.Application.Users.Services.UpdateUserImage
{
    public interface IUpdateUserImageService
    {
        Task ExecuteAsync(UpdateUserImageServiceInput input);
    }
}
