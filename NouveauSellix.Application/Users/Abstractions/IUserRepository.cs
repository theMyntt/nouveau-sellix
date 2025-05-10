using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NouveauSellix.Domain.Users.Entities;
using NouveauSellix.Domain.Users.ValueObjects;

namespace NouveauSellix.Application.Users.Abstractions
{
    public interface IUserRepository
    {
        Task SaveUserAsync(UserEntity user);
        Task<UserEntity> SearchByEmailAsync(EmailValueObject email);
        Task UpdateUserImage(UserEntity user, string path);
    }
}
