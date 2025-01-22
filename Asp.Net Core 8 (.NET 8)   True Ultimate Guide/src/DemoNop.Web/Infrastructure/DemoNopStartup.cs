using DemoNop.Core.Infrastructure;
using DemoNop.Data;
using DemoNop.Services;
using DemoNop.Web.Factories;

namespace DemoNop.Web.Infrastructure
{
    public class DemoNopStartup : INopStartup
    {
        /// <summary>
        /// Gets order of this startup configuration implementation
        /// </summary>
        public int Order => 2222;

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        /// <summary>
        /// Represents the registering services on application startup
        /// </summary>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //factories
            services.AddScoped<ICustomerModelFactory, CustomerModelFactory>();
            services.AddScoped<IProductModelFactory, ProductModelFactory>();
            services.AddScoped<IUserInfoFactory, UserInfoFactory>();
            //common factories


            services.AddSwaggerGen();
        }
    }
}
