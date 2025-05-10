using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NouveauSellix.Domain.Shared
{
    public class HttpException : Exception
    {
        public int StatusCode { get; private set; }

        public HttpException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
