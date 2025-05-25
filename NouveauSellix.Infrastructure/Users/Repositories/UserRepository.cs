using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Domain.Users.Entities;
using NouveauSellix.Domain.Users.ValueObjects;
using NouveauSellix.Infrastructure.Shared;
using NouveauSellix.Infrastructure.Users.Repositories.Exceptions;
using NouveauSellix.Infrastructure.Users.Repositories.Mappers;
using NouveauSellix.Infrastructure.Users.Tables;

namespace NouveauSellix.Infrastructure.Users.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<UserTable> _table;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
            _table = _context.Set<UserTable>();
        }

        public async Task SaveUserAsync(UserEntity user)
        {
            var table = await _table.SingleOrDefaultAsync(u => u.Email == user.Email.Value && u.IsDeleted == false);

            if (table is not null)
            {
                if (!table.IsDeleted)
                {
                    throw new UserAlreadyExistsException();
                }

                _table.Remove(table);
                await _context.SaveChangesAsync();
            }

            table = user.ToTable();

            await _table.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> SearchByEmailAsync(EmailValueObject email)
        {
            var user = await _table
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Email == email.Value && u.IsDeleted == false);

            if (user is null)
                throw new UserNotFoundException();

            return user.ToEntity();
        }

        public async Task UpdateUserImage(UserEntity user, string path)
        {
            var table = user.ToTable();

            table.ImagePath = path;

            _table.Attach(table);
            _table.Entry(table).Property(u => u.ImagePath).IsModified = true;

            await _context.SaveChangesAsync();
        }
    }
}
