using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Application.Users.Services.RefreshToken.IO;

namespace NouveauSellix.Application.Users.Services.RefreshToken
{
    public interface IRefreshTokenService
    {
        Task<RefreshTokenServiceOutput> ExecuteAsync(RefreshTokenServiceInput input);
    }
}
