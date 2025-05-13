using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NouveauSellix.Application.Users.Abstractions;
using NouveauSellix.Application.Users.Services.CreateUser;
using NouveauSellix.Application.Users.Services.CreateUser.Implementations;
using NouveauSellix.Application.Users.Services.Login;
using NouveauSellix.Application.Users.Services.Login.Implementations;
using NouveauSellix.Application.Users.Services.RefreshToken;
using NouveauSellix.Application.Users.Services.RefreshToken.Implementations;
using NouveauSellix.Application.Users.Services.UpdateUserImage;
using NouveauSellix.Application.Users.Services.UpdateUserImage.Implementations;
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

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]!))
                    };
                });
            services.AddAuthorization();
        }

        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserService, CreateUserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUpdateUserImageService, UpdateUserImageService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();
        }
    }
}
