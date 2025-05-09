using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NouveauSellix.Domain.Users.ValueObjects
{
    public class EmailValueObject
    {
        public string Value { get; private set; }

        public EmailValueObject(string value)
        {
            if (!IsValidEmail(value))
                throw new ArgumentException("Invalid email.", nameof(value));

            Value = value;
        }

        private static bool IsValidEmail(string email)
        {
            var regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return regex.IsMatch(email);
        }
    }
}
