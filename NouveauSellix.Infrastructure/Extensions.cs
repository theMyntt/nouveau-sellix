using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Infrastructure.Shared;
using NouveauSellix.Infrastructure.Users.Handlers;
using NouveauSellix.Infrastructure.Users.Repositories;

namespace NouveauSellix.Infrastructure
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var conn = configuration["SqlServer:ConnectionString"] ?? throw new Exception("SqlServer:ConnectionString Is Null");

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(conn, o =>
                {
                    o.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName);
                });
            });
            services.AddScoped<IJwtHandler, JwtHandler>();
            services.AddScoped<IUserFileManager, UserFileManager>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
