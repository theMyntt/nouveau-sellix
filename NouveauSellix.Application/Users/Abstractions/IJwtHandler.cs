using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Users.Entities;

namespace NouveauSellix.Application.Users.Abstractions
{
    public interface IJwtHandler
    {
        string GenerateToken(UserEntity user);

        /// <summary>
        /// Verifica a autênticidade do token JWT, se 
        /// autêntico, retorna suas Claims. Se não, estoura a 
        /// exceção UnAuthenticJwtTokenException
        /// </summary>
        /// <param name="token">String do token JWT</param>
        /// <returns></returns>
        /// <exception cref="UnAuthenticJwtTokenException">Token não autêntico ou invalido</exception>
        ClaimsPrincipal IsAuthentic(string token);
    }
}
