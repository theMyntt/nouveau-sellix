using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Shared;

namespace NouveauSellix.Application.Users.Services.RefreshToken.Implementations.Exceptions
{
    public class InvalidJwtTokenException() : HttpException("Token inválido", 400)
    {
    }
}
