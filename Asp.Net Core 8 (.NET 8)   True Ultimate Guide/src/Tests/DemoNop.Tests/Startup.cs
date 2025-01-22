using DemoNop.Data;
using DemoNop.Services.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace DemoNop.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NorthwindDBContext>(
                options => options.UseMySQL("server=127.0.0.1;database=northwind;user=root;password=20150601" ?? string.Empty));
            services.AddTransient(typeof(INopDataProvider), typeof(BaseDataProvider));
            //repositories	
            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
            services.AddTransient<IUserInfoService, UserInfoService>();
        }
    }
}