using DnnSummit.Data.Services;
using DnnSummit.Data.Services.Interfaces;
using MonkeyCache.SQLite;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Linq;
using System.Reflection;

namespace DnnSummit.Data
{
    public class DataModule : IModule
    {
        internal const string BarrelName = "DnnSummit2019";
        public void OnInitialized(IContainerProvider containerProvider)
        {
            Barrel.ApplicationId = BarrelName;

            var interfaces = GetAllSyncServiceInterfaces();
            var startup = containerProvider.Resolve<IStartupManager>();
            foreach (var syncServiceInterface in interfaces)
            {
                startup.Services.Add((ISyncService)containerProvider.Resolve(syncServiceInterface));
            }
        }

        private Type[] GetAllSyncServiceInterfaces()
        {
            return Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.IsInterface && typeof(ISyncService).IsAssignableFrom(x) &&
                       x != typeof(IService<>) && x != typeof(ISyncService))
                .ToArray();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILocationService, LocationService>();
            containerRegistry.Register<ISessionService, SessionService>();
            containerRegistry.Register<IScheduleService, ScheduleService>();
            containerRegistry.Register<ISpeakerService, SpeakerService>();
            containerRegistry.Register<ISponsorService, SponsorService>();
            containerRegistry.Register<ISettingsService, SettingsService>();
            containerRegistry.RegisterSingleton<IStartupManager, StartupManager>();
        }
    }

}
