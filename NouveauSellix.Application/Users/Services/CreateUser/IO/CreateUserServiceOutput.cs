using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Users.Entities;

namespace NouveauSellix.Application.Users.Services.CreateUser.IO
{
    public class CreateUserServiceOutput
    {
        public required string Message { get; set; } 
        public required UserEntity User { get; set; }
        public required int StatusCode { get; set; }
    }
}
