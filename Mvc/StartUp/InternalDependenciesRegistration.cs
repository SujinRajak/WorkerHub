
using Microsoft.AspNetCore.Identity;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Mvc.Interfaces;
using Mvc.Services;
using Mvc.Services.Email;
using WorkerHub.Infrastructure.Data;

namespace Mvc.Startup
{
    public static class InternalDependenciesRegistration
    {
        public static void AddInternalDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserClaimsPrincipalFactory<ApplicationUser>, ClaimPrincipalFactory>();
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddTransient<IApplicationUser, ApplicationUserService>();
            services.AddScoped<IGenericUnitOfWork, GenericUnitOfWork>();
            services.AddScoped<IGenericUnitOfWork, GenericUnitOfWork>();
            services.AddScoped<IAdmin, AdminService>();
            services.AddHttpContextAccessor();
        }
    }
}
