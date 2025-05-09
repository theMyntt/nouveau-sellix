using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Users.Entities;

namespace NouveauSellix.Application.Users.Abstractions
{
    public interface IJwtHandler
    {
        string GenerateToken(UserEntity user);
    }
}
