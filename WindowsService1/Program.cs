using FileMonitor.Common;
using FileMonitor.Common.Interfaces;
using FileMonitor.DataStores.Implementation;
using FileMonitor.DataStores.Infrastructure;
using FileMonitor.DataStores.Interfaces;
using FileMonitor.IOServices;
using FileMonitor.IOServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace WindowsService1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            // Register services
            ConfigureServices();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };
            ServiceBase.Run(ServicesToRun);
        }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddScoped<IApplicationConfiguration, ApplicationConfiguration>();
            services.AddScoped<IFile, FileService>();
            services.AddScoped<IDbContext, MsSqlDbContext>();            

            Assembly.GetAssembly(typeof(UnitOfWork))
                    .GetTypes()
                    .Where(a => a.Name.EndsWith("Repository"))
                    .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
                    .ToList()
                    .ForEach(typesToRegister =>
                    {
                        typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typesToRegister.assignedType));
                    });
        }
    }
}
