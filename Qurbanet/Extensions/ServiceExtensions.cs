using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Qurbanet.Database;
using Qurbanet.Database.Repositories;
using Qurbanet.Models.Mappers;
using Qurbanet.Services;
using Qurbanet.Services.Interfaces;

namespace Qurbanet.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext yapılandırması
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            // Repository'ler
            services.AddScoped(typeof(BaseRepository<>));
            services.AddScoped<UserRepository>();

            // Service'ler
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // FluentValidation
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);

            // AutoMapper
            services.AddAutoMapper(typeof(UserProfile).Assembly);

            return services;
        }
    }
}
