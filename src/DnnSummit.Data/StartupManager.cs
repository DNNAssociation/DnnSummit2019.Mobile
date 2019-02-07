using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Events;
using MonkeyCache.SQLite;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DnnSummit.Data
{
    internal class StartupManager : IStartupManager
    {
        private CancellationTokenSource _cancellationTokenSource;
        private IDictionary<string, object> _cachedData;
        private DateTime? _cachedExpiration;
        private bool _isCancelled = false;
        protected IEventAggregator EventAggregator { get; }

        public IList<ISyncService> Services { get; private set; }

        public StartupManager(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            Barrel.ApplicationId = DataModule.BarrelName;
            Services = new List<ISyncService>();
        }

        public bool ContainsData
        {
            get
            {
                return !Services.Any(x => Barrel.Current.IsExpired(x.Method));
            }
        }

        public void CancelDataUpdate()
        {
            if (_cancellationTokenSource == null) return;
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = null;
            _isCancelled = true;

            if (_cachedData == null) return;

            foreach (var item in _cachedData)
            {
                Barrel.Current.Add(item.Key, item.Value, _cachedExpiration.Value.Subtract(DateTime.Now));
            }
        }

        public async Task SyndDataAsync()
        {
            _cachedData = GetCachedData();
            _cachedExpiration = Barrel.Current.GetExpiration(nameof(Settings));
            _cancellationTokenSource = new CancellationTokenSource();

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
                    }), _cancellationTokenSource.Token));
                }
                catch (Exception)
                {
                    // TODO - log error
                }
            }

            await Task.WhenAll(serviceTasks);

            if (!_isCancelled)
            {
                var settings = new Settings { LastUpdated = DateTime.Now };
                Barrel.Current.Add(nameof(Settings), settings, TimeSpan.FromDays(5));
                Barrel.Current.Add("DownloadPermission", _cachedData["DownloadPermission"], TimeSpan.FromDays(100));
            }
        }

        private IDictionary<string, object> GetCachedData()
        {
            var result = new Dictionary<string, object>();
            foreach (var syncservice in Services)
            {
                var data = Barrel.Current.Get<object>(syncservice.Method);
                result.Add(syncservice.Method, data);
            }

            result.Add(nameof(Settings), Barrel.Current.Get<object>(nameof(Settings)));

            if (Barrel.Current.Exists("DownloadPermission"))
                result.Add("DownloadPermission", Barrel.Current.Get<object>("DownloadPermission"));

            return result;
        }
    }
}
