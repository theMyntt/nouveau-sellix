using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Shared;

namespace NouveauSellix.Infrastructure.Users.Repositories.Exceptions
{
    public class UserNotFoundException() : HttpException("Nenhum usuário encontrado", 404)
    {
    }
}
