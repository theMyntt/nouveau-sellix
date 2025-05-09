using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Application.Users.Services.Login.IO;

namespace NouveauSellix.Application.Users.Services.Login
{
    public interface ILoginService
    {
        Task<LoginServiceOutput> ExecuteAsync(LoginServiceInput input);
    }
}
