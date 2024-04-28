
namespace WorkerHub.Application.Startup
{
    public static class InternalDependenciesRegistration
    {
        public static void AddInternalDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
