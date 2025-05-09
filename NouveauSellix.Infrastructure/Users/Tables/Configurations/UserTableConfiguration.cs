using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NouveauSellix.Infrastructure.Users.Tables.Configurations
{
    public class UserTableConfiguration : IEntityTypeConfiguration<UserTable>
    {
        public void Configure(EntityTypeBuilder<UserTable> builder)
        {
            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
