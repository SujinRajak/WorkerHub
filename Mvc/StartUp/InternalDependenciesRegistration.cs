﻿
using Microsoft.AspNetCore.Identity;
using Domain.Interfaces;
using Infrastructure.Data;
using Helper;
using Infrastructure.Identity;
using Mvc.Interfaces;
using Mvc.Services;
using Mvc.Services.Email;

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
            services.AddHttpContextAccessor();
        }
    }
}
