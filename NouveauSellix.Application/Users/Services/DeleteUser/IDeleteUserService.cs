using NouveauSellix.Application.Users.Services.DeleteUser.Implementations;
using NouveauSellix.Application.Users.Services.DeleteUser.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NouveauSellix.Application.Users.Services.DeleteUser
{
    public interface IDeleteUserService
    {
        Task ExecuteAsync(DeleteUserServiceInput input);
    }
}
