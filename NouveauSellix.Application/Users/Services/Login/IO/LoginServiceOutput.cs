using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NouveauSellix.Application.Users.Services.Login.IO
{
    public class LoginServiceOutput
    {
        public required string Message { get; set; }
        public required string Token { get; set; }
        public required int StatusCode { get; set; }
    }
}
