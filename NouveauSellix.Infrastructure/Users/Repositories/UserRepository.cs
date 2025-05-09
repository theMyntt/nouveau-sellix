using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Domain.Users.Entities;
using NouveauSellix.Domain.Users.ValueObjects;
using NouveauSellix.Infrastructure.Shared;
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
            var table = user.ToTable();

            await _table.AddAsync(table);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity?> SearchByEmailAsync(EmailValueObject email)
        {
            var user = await _table.SingleOrDefaultAsync(u => u.Email == email.Value);

            return user?.ToEntity();
        }
    }
}
