using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Pottencial.Teste.Presentation.Api.Configurations
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "DocumentingSwagger.Pottencial.API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Ari C. Maximiano",
                        Email = "ari.maximiano@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/ari-maximiano/")

                    }
                })
            );

            return services;
        }
    }
}
