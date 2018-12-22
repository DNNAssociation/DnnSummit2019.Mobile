using DnnSummit.Data.Models;
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
            container.Register<ISettingsService, SettingsService>();
        }

        public static void Initialize()
        {
            Barrel.ApplicationId = Startup.BarrelName;
        }

        public static event EventHandler ProgressUpdated;

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

                    if (ProgressUpdated != null)
                    {
                        double progress = (index + 1) / (double)interfaces.Length;
                        ProgressUpdated.Invoke(progress, new EventArgs());
                    }
                }
                catch (Exception)
                {
                    // TODO - log error
                }
            }

            var settings = new Settings { LastUpdated = DateTime.UtcNow };
            Barrel.Current.Add(nameof(Settings), settings, TimeSpan.FromDays(5));
        }
    }
}
