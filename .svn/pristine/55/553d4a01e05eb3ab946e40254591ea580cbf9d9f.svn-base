using Autofac;
using Autofac.Core;
using _365Plus.Core.Caching;
using _365Plus.Core.Configuration;
using _365Plus.Core.Infrastructure;
using _365Plus.Core.Infrastructure.DependencyManagement;
using _365Plus.Web.Controllers;

namespace _365Plus.Web.Infrastructure
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, PlusConfig config)
        {
            //we cache presentation models between requests
            builder.RegisterType<HomeController>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("plus_cache_static"));
        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 2; }
        }
    }
}