using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Users.ValueObjects;

namespace NouveauSellix.Tests.Domain.Users.ValueObjects
{
    public class EmailValueObjectTests
    {
        [Fact]
        public void ShouldCreateEmail()
        {
            var email = "john.doe@example.com";
            var obj = new EmailValueObject(email);

            Assert.Equal(email, obj.Value);
        }

        [Fact]
        public void ShouldBlockEmail()
        {
            var email = "john.doe";

            Assert.Throws<ArgumentException>(() => new EmailValueObject(email));
        }
    }
}
