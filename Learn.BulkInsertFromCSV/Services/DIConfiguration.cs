using Learn.BulkInsertFromCSV.Context;
using Learn.BulkInsertFromCSV.DbManagers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learn.BulkInsertFromCSV.Services
{
    public static class DIConfiguration
    {
        //public IHostBuilder RegisterServices()
        //{
        //    return Host.CreateDefaultBuilder()
        //        .ConfigureAppConfiguration((context, configuration) =>
        //        {
        //            configuration.Sources.Clear();
        //            configuration.AddJsonFile("appsettings.json", true, true);
        //        });
        //}
        public static ServiceCollection RegisterServices(this ServiceCollection serviceCollection)
        {
            //var serviceCollection = new ServiceCollection();

            IConfiguration configuration;
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json",true, true)
                .Build();

            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddDbContext<ApplicationDbContext>(o => o.UseSqlServer(configuration.GetConnectionString("Default")));
            serviceCollection.AddScoped<DapperBulk>();
            serviceCollection.AddScoped<DefaultSqlBulkCopy>();
            return serviceCollection;
        }
    }
}
