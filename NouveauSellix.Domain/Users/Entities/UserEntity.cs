using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using NouveauSellix.Domain.Users.ValueObjects;

namespace NouveauSellix.Domain.Users.Entities
{
    public class UserEntity
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public EmailValueObject Email { get; private set; }

        [JsonIgnore]
        public PasswordValueObject Password { get; private set; }
        public bool IsBlocked { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        public UserEntity(string name, EmailValueObject email, PasswordValueObject password, bool isBlocked, DateTime createdAt, Guid? id = null, DateTime? updatedAt = null)
        {
            Name = name;
            Email = email;
            Password = password;
            IsBlocked = isBlocked;
            CreatedAt = createdAt;
            Id = id ?? Guid.NewGuid();
            UpdatedAt = updatedAt;
        }
    }
}
