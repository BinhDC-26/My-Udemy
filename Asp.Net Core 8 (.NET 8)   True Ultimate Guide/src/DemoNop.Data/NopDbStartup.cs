using Autofac.Core;
using DemoNop.Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoNop.Data
{
    public class NopDbStartup : INopStartup
    {
        public int Order => 10;

        public void Configure(IApplicationBuilder application)
        {
            
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NorthwindDBContext>(
                options => options.UseMySQL(configuration.GetConnectionString("Default") ?? string.Empty));
            //data layer
            //services.AddTransient<IDataProviderManager, DataProviderManager>();
            //services.AddTransient(serviceProvider =>
            //    serviceProvider.GetRequiredService<IDataProviderManager>().DataProvider);
            services.AddTransient(typeof(INopDataProvider), typeof(BaseDataProvider));
            //repositories	
            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
        }
    }
}