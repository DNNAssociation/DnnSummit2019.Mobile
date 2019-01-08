using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Events;
using MonkeyCache.SQLite;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnnSummit.Data
{
    internal class StartupManager : IStartupManager
    {   
        protected IEventAggregator EventAggregator { get; }

        public IList<ISyncService> Services { get; private set; }
        public StartupManager(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            Barrel.ApplicationId = DataModule.BarrelName;
            Services = new List<ISyncService>();
        }

        public async Task SyndDataAsync()
        {
            Barrel.Current.EmptyAll();
           
            var serviceTasks = new List<Task>();
            double counter = 0;
            foreach (var syncService in Services)
            {
                try
                {
                    serviceTasks.Add(Task.Run(new Func<Task>(async () =>
                    {
                        await syncService.SyncAsync();

                        counter += 1 / (double)Services.Count;
                        EventAggregator
                            .GetEvent<ContentDownloadProgressUpdated>()
                            .Publish(counter);
                    })));
                }
                catch (Exception)
                {
                    // TODO - log error
                }
            }

            await Task.WhenAll(serviceTasks);
            var settings = new Settings { LastUpdated = DateTime.UtcNow };
            Barrel.Current.Add(nameof(Settings), settings, TimeSpan.FromDays(5));
        }
    }
}
