using DnnSummit.Data.Services;
using DnnSummit.Data.Services.Interfaces;
using MonkeyCache.SQLite;
using Prism.Ioc;

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
    }
}
