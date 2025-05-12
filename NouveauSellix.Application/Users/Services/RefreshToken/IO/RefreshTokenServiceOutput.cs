using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NouveauSellix.Application.Users.Services.RefreshToken.IO
{
    public class RefreshTokenServiceOutput
    {
        public string Message { get; set; } = string.Empty;
        public string NewToken { get; set; } = string.Empty;
        public int StatusCode { get; set; }
    }
}
