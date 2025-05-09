using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Application.Users.Services.CreateUser.IO;

namespace NouveauSellix.Application.Users.Services.CreateUser
{
    public interface ICreateUserService
    {
        Task<CreateUserServiceOutput> ExecuteAsync(CreateUserServiceInput input);
    }
}
