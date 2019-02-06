using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class CreditsViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        public string Title => "Credits";
        protected ICreditService CreditService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }
        public ObservableCollection<Credit> Credits { get; }
        public ICommand OpenCredit { get; }
        public CreditsViewModel(
            ICreditService creditService,
            IErrorRetryManager errorRetryManager)
        {
            CreditService = creditService;
            ErrorRetryManager = errorRetryManager;
            Credits = new ObservableCollection<Credit>();
            OpenCredit = new DelegateCommand<Credit>(OnOpenCredit);
        }

        private void OnOpenCredit(Credit credit)
        {
            if (credit != null && !string.IsNullOrWhiteSpace(credit.Website))
            {
                Device.OpenUri(new Uri(credit.Website));
            }
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            await OnLoadAsync(parameters);
        }

        public async Task OnLoadAsync(INavigationParameters parameters, int attempt = 0)
        {
            try
            {
                var data = await CreditService.GetAsync();

                Credits.Clear();

                foreach (var item in data.OrderBy(x => x.CreditType))
                {
                    Credits.Add(new Credit
                    {
                        Title = item.Title,
                        CreditType = (CreditType)item.CreditType,
                        Description = item.Description,
                        Website = item.Website,
                        IncludeTitle = item.IncludeTitle,
                        Logo = ImageSource.FromStream(() => new MemoryStream(item.Logo))
                    });
                }
            }
            catch (Exception)
            {
                await ErrorRetryManager.HandleRetryAsync(this, parameters, attempt);
            }
        }
    }
}
