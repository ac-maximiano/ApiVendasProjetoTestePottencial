using Pottencial.Teste.Application.Mappings;
using Pottencial.Teste.Presentation.Api.Mappings;

namespace Pottencial.Teste.Presentation.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationProfile));
            services.AddAutoMapper(typeof(PresentationProfile));

            return services;
        }
    }
}
