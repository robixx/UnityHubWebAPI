using UnityHubWebAPI.Helpers;
using UnityHubWebAPI.IServices;
using UnityHubWebAPI.Services;

namespace UnityHubWebAPI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<LoginService>();
            services.AddScoped<LoginRepository>();
            services.AddScoped<ILoginUserService, LoginUserService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<ICategoryServices, CategoryServices>();

            return services;
        }
    }
}
