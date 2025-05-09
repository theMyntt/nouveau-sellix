using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Users.Entities;
using NouveauSellix.Domain.Users.ValueObjects;
using NouveauSellix.Infrastructure.Users.Tables;

namespace NouveauSellix.Infrastructure.Users.Repositories.Mappers
{
    public static class UserMapper
    {
        public static UserTable ToTable(this UserEntity entity)
        {
            return new UserTable
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email.Value,
                PasswordHash = entity.Password.Hash,
                PasswordSalt = entity.Password.Salt,
                ImagePath = entity.ImagePath,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static UserEntity ToEntity(this UserTable table)
        {
            var email = new EmailValueObject(table.Email);
            var password = new PasswordValueObject(table.PasswordHash, table.PasswordSalt);

            return new UserEntity(
                table.Name,
                email,
                password,
                table.IsBlocked,
                table.CreatedAt,
                table.Id,
                table.UpdatedAt,
                table.ImagePath);
        }
    }
}
