using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Shared;

namespace NouveauSellix.Infrastructure.Users.Handlers.Exceptions
{
    public class UnAuthenticJwtTokenException() : HttpException("Seu token não é autentico", 400)
    {
    }
}
