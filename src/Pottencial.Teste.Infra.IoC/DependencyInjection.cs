using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pottencial.Teste.Application.Interfaces;
using Pottencial.Teste.Application.Services;
using Pottencial.Teste.Domain.Interfaces;
using Pottencial.Teste.Infra.Data.Repository;

namespace Pottencial.Teste.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEFContexts(configuration);

            #region Register Domain/Application Services
            services.AddScoped<IVendaRepository, VendaRespository>();
            services.AddScoped<IVendedorRepository, VendedorRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IItemVendaRepository, ItemVendaRepository>();
            services.AddScoped<IVendaService, VendaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IVendedorService, VendedorService>();
            #endregion

            return services;
        }
    }
}
