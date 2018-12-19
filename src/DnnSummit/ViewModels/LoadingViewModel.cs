using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;

namespace DnnSummit.ViewModels
{
    public class LoadingViewModel : BindableBase, INavigatingAware
    {
        private double _percentCompleted;
        public double PercentCompleted
        {
            get { return _percentCompleted; }
            set
            {
                SetProperty(ref _percentCompleted, value);
                RaisePropertyChanged(nameof(PercentCompleted));
            }
        }
        
        public LoadingViewModel()
        {
        }

        private async Task DownloadAsync()
        {
            Data.Startup.ProgressUpdated += OnProgressUpdated;
            await Data.Startup.SyndDataAsync(App.Current.Container);
            Data.Startup.ProgressUpdated -= OnProgressUpdated;
        }

        private void OnProgressUpdated(object sender, EventArgs e)
        {
            PercentCompleted = (double)sender;
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            PercentCompleted = 0.0d;
            await DownloadAsync();
        }
    }
}
