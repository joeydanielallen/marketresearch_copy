using afmr.api.Security;
using afmr.data;
using afmr.domain.Security;
using afmr.model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace afmr.api.Extensions
{
    internal static class InjectionExtensions
    {
        internal static void RegisterDependencies(
            this IServiceCollection services,
            IConfigurationRoot appSettings)
        {
            var connectionString = appSettings.GetConnectionString("MarketResearch");

            services.AddSingleton<IAppConfig>((svcProvider) => new Config(appSettings));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //logging
            services.AddScoped<model.ILogger, Logger>();

            //data
            services.AddScoped<IUnitOfWork>((svcProvider) => new UnitOfWork(connectionString));

            //security
            services.AddScoped<IUserIdentity, MarketResearchUserIdentity>();

            services.AddSingleton<IConfig>((svcProvider) => new Config(appSettings));

            //domain
            var ODInjectables = InjectionExtensions
                .GetReferencingAssemblies("afmr.domain")
                .SelectMany(assembly => assembly.ExportedTypes)
                .Where(x => x.FullName.StartsWith("afmr.domain") &&
                (x.FullName.EndsWith("Service") &&
                    !x.FullName.EndsWith(".IService")))
                .ToList();

            ODInjectables.ForEach(x =>
            {
                if (x.IsInterface)
                {
                    var implementation = ODInjectables
                    .Where(k => x.IsAssignableFrom(k) &&
                    k.IsClass)
                    .First();

                    services.AddScoped(x, implementation);
                }
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static IEnumerable<Assembly> GetReferencingAssemblies(string assemblyName)
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries;
            foreach (var library in dependencies)
            {
                if (IsCandidateLibrary(library, assemblyName))
                {
                    var assembly = Assembly.Load(new AssemblyName(library.Name));
                    assemblies.Add(assembly);
                }
            }
            return assemblies;
        }

#pragma warning disable CA1307 // Specify StringComparison
        private static bool IsCandidateLibrary(RuntimeLibrary library, string assemblyName)
        {
            return library.Name == (assemblyName)
                || library.Dependencies.Any(d => d.Name.StartsWith(assemblyName));
        }
#pragma warning restore CA1307 // Specify StringComparison

    }
}
