using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Qurbanet.Database;
using Qurbanet.Database.Repositories;
using Qurbanet.Models.Mappers;
using Qurbanet.Services;
using Qurbanet.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Qurbanet.Services.Common;

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
            services.AddScoped<AnimalRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            // Service'ler
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ISaleService, SaleService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ICuttingEventService, CuttingEventService>();
            services.AddScoped<ISystemLogService, SystemLogService>();
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
