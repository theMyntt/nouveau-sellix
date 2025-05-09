using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NouveauSellix.Domain.Users.ValueObjects
{
    public class PasswordValueObject
    {
        public string Hash { get; private set; }
        public byte[] Salt { get; private set; }

        public PasswordValueObject(string password)
        {
            using var hmac = new HMACSHA256();

            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            Salt = hmac.Key;
            Hash = Convert.ToBase64String(hashBytes);
        }

        public PasswordValueObject(string hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }

        public bool MatchesWith(string password)
        {
            using var hmac = new HMACSHA256(Salt);

            var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            return Convert.ToBase64String(hashBytes) == Hash;
        }
    }
}
