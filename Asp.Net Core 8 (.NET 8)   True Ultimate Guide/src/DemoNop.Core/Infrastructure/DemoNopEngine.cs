using AutoMapper;
using DemoNop.Core.Infrastructure.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DemoNop.Core.Infrastructure
{
    public partial class DemoNopEngine : IEngine
    {
        #region Utilities

        /// <summary>
        /// Register and configure AutoMapper
        /// </summary>
        protected virtual void AddAutoMapper()
        {
            //find mapper configurations provided by other assemblies
            var typeFinder = Singleton<ITypeFinder>.Instance;
            var mapperConfigurations = typeFinder.FindClassesOfType<IOrderedMapperProfile>();

            //create and sort instances of mapper configurations
            var instances = mapperConfigurations
                .Select(mapperConfiguration => (IOrderedMapperProfile)Activator.CreateInstance(mapperConfiguration))
                .OrderBy(mapperConfiguration => mapperConfiguration.Order);

            //create AutoMapper configuration
            var config = new MapperConfiguration(cfg =>
            {
                foreach (var instance in instances)
                {
                    cfg.AddProfile(instance.GetType());
                }
            });

            //register
            AutoMapperConfiguration.Init(config);
        }
        #endregion Utilities
        #region Methods
        public virtual void ConfigureRequestPipeline(IApplicationBuilder application)
        {
            ServiceProvider = application.ApplicationServices;

            //find startup configurations provided by other assemblies
            var typeFinder = Singleton<ITypeFinder>.Instance;
            var startupConfigurations = typeFinder.FindClassesOfType<INopStartup>();

            //create and sort instances of startup configurations
            var instances = startupConfigurations
                .Select(startup => (INopStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup.Order);

            //configure request pipeline
            foreach (var instance in instances)
                instance?.Configure(application);
        }

        /// <summary>
        /// Add and configure services
        /// </summary>
        /// <param name="services">Collection of service descriptors</param>
        /// <param name="configuration">Configuration of the application</param>
        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            //register engine
            services.AddSingleton<IEngine>(this);

            //find startup configurations provided by other assemblies
            var typeFinder = Singleton<ITypeFinder>.Instance;
            var startupConfigurations = typeFinder.FindClassesOfType<INopStartup>();

            //create and sort instances of startup configurations
            var instances = startupConfigurations
                .Select(startup => (INopStartup)Activator.CreateInstance(startup))
                .OrderBy(startup => startup?.Order);

            //configure services
            foreach (var instance in instances)
                instance?.ConfigureServices(services, configuration);

            services.AddSingleton(services);

            //register mapper configurations
            AddAutoMapper();

        }

        public T Resolve<T>(IServiceScope? scope = null) where T : class
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type, IServiceScope? scope = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            throw new NotImplementedException();
        }

        public object ResolveUnregistered(Type type)
        {
            throw new NotImplementedException();
        }
        #endregion Methods
        #region Properties
        /// <summary>
        /// Service provider
        /// </summary>
        public virtual IServiceProvider? ServiceProvider { get; protected set; }
        #endregion Properties
    }
}
