using System;
using System.Threading.Tasks;
using DnnSummit.Manager.Interfaces;
using DnnSummit.ViewModels.Interfaces;
using Prism.Navigation;

namespace DnnSummit.Manager
{
    public class ErrorRetryManager : IErrorRetryManager
    {
        public async Task HandleRetryAsync(IHasDataRetrieval viewmodel, INavigationParameters parameters, int attempt = 0)
        {
            if (attempt < Constants.ErrorHandling.RetryAttempts)
            {
                await Task.Delay(Constants.ErrorHandling.RetryWait);
                await viewmodel.OnLoadAsync(parameters, attempt + 1);
            }
        }
    }
}
