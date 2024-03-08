using Pottencial.Teste.Presentation.Api.Filters;

namespace Pottencial.Teste.Presentation.Api.Configurations
{
    public static class ApiConfiguration
    {
        public static IServiceCollection AddFilters(this IServiceCollection services)
        {
            services.AddScoped<CustomExceptionFilter>();

            return services;
        }
    }
}
