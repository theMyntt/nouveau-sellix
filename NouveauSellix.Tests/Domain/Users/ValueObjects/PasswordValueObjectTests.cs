using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Users.ValueObjects;

namespace NouveauSellix.Tests.Domain.Users.ValueObjects
{
    public class PasswordValueObjectTests
    {
        [Fact]
        public void ShouldGenerateHashAndSalt()
        {
            var password = "mypasswordkey";
            var obj = new PasswordValueObject(password);

            Assert.NotNull(obj.Hash);
            Assert.NotEmpty(obj.Salt);
        }

        [Fact]
        public void ShouldMatchPasswords()
        {
            var password = "mypasswordkey";
            var obj = new PasswordValueObject(password);

            Assert.NotNull(obj.Hash);
            Assert.NotEmpty(obj.Salt);

            var isEqual = obj.MatchesWith(password);

            Assert.True(isEqual);
        }

        [Fact]
        public void ShouldNotMatchPasswords()
        {
            var password = "mypasswordkey";
            var anotherPassword = "mypasskey";
            var obj = new PasswordValueObject(password);

            Assert.NotNull(obj.Hash);
            Assert.NotEmpty(obj.Salt);

            var isEqual = obj.MatchesWith(anotherPassword);

            Assert.False(isEqual);
        }
    }
}
