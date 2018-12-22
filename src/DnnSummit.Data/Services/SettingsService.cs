using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using MonkeyCache.SQLite;

namespace DnnSummit.Data.Services
{
    internal class SettingsService : ISettingsService
    {
        public Settings Get()
        {
            return Barrel.Current.Get<Settings>(nameof(Settings));
        }
    }
}
