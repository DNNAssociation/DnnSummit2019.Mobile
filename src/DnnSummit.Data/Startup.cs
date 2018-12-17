using DnnSummit.Data.Services;
using DnnSummit.Data.Services.Interfaces;
using MonkeyCache.SQLite;
using Prism.Ioc;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DnnSummit.Data
{
    public static class Startup
    {   
        internal const string BarrelName = "DnnSummit2019";
        public static void RegisterDependencies(IContainerRegistry container)
        {
            container.Register<ILocationService, LocationService>();
            container.Register<ISessionService, SessionService>();
            container.Register<IScheduleService, ScheduleService>();
            container.Register<ISpeakerService, SpeakerService>();
            container.Register<ISponsorService, SponsorService>();
        }

        public static void Initialize()
        {
            Barrel.ApplicationId = Startup.BarrelName;
        }

        public static async Task SyndDataAsync(IContainerProvider container)
        {
            Barrel.Current.EmptyAll();
            var interfaces = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsInterface && typeof(ISyncService).IsAssignableFrom(x) && 
                       x != typeof(IService<>) && x != typeof(ISyncService))
                .ToArray();

            for(int index = 0; index < interfaces.Length; index++)
            {
                try
                {
                    var service = (ISyncService)container.Resolve(interfaces[index]);
                    if (service == null) continue;

                    await service.SyncAsync();
                }
                catch (Exception)
                {
                    // TODO - log error
                }
            }
        }
    }
}
