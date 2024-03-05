using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pottencial.Teste.Infra.Data.Context;

namespace Pottencial.Teste.Infra.IoC
{
    public static class EfContextsConfiguration
    {
        public static IServiceCollection AddEFContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var sqliteFolderPath = GetSqliteFolderPath();
            var appDbContextConnectionString = string.Format(configuration.GetConnectionString("DefaultConnection"), sqliteFolderPath);

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(appDbContextConnectionString));

            return services;
        }

        private static string GetSqliteFolderPath()
        {
            var srcPath = Directory.GetParent(Environment.CurrentDirectory).FullName;
            var databaseFolderPath = Path.Combine(srcPath, "Data");

            if (!Directory.Exists(databaseFolderPath)) Directory.CreateDirectory(databaseFolderPath);

            return databaseFolderPath;
        }
    }
}
