using DemoNop.Core.Infrastructure;
using DemoNop.Services;
using DemoNop.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DemoNop.Web.Framework.Infrastructure
{
    public class DemoNopStartup : INopStartup
    {
        public int Order => 2000;

        public void Configure(IApplicationBuilder application)
        {
            //ExceptionHandler
            //HSTS
            //HttpsRedirection
            //Staticfile
            //Routing
            application.UseRouting();
            //CORS
            application.UseCors();
            //Authentication
            application.UseAuthentication();
            //Authorization
            application.UseAuthorization();
            //Endpoint
            application.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //ExceptionHandler
            //HSTS
            //HttpsRedirection
            //Staticfile
            //Routing
            //CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins(configuration.GetSection("AllowedOrigins").Get<string[]>())
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            //Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
            //Authorization
            //Endpoint

            //add Controller
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(DemoNopExceptionFilter));
            }).ConfigureApiBehaviorOptions(options => {
                options.SuppressModelStateInvalidFilter = true;
            });
            //services
            services.AddScoped(typeof(ICustomerService), typeof(CustomerService));
            services.AddScoped(typeof(IProductService), typeof(ProductService));
            services.AddScoped(typeof(IUserInfoService), typeof(UserInfoService));
        }
    }
}
