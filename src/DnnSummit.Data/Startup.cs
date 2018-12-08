using DnnSummit.Data.Services;
using DnnSummit.Data.Services.Interfaces;
using Prism.Ioc;

namespace DnnSummit.Data
{
    public static class Startup
    {
        public static void RegisterDependencies(IContainerRegistry container)
        {
            container.Register<ISessionService, SessionService>();
            container.Register<IScheduleService, ScheduleService>();
            container.Register<ISpeakerService, SpeakerService>();
        }
    }
}
