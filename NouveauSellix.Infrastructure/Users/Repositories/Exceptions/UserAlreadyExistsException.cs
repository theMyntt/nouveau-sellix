using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Shared;

namespace NouveauSellix.Infrastructure.Users.Repositories.Exceptions
{
    public class UserAlreadyExistsException() : HttpException("User Already Exists", 409)
    {
    }
}
