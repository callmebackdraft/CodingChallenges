using Microsoft.Extensions.DependencyInjection;

namespace InnoTractor.Assignment3Logic
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterRunningTotalService(this IServiceCollection services)
        {
            services.AddSingleton<IRunningTotal, RunningTotalService>();
            return services;
        }
    }
}
