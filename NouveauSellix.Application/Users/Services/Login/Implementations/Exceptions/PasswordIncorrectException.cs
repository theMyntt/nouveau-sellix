using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Shared;

namespace NouveauSellix.Application.Users.Services.Login.Implementations.Exceptions
{
    public class PasswordIncorrectException() : HttpException("Senha incorreta.", 400)
    {
    }
}
