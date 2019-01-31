using DnnSummit.ViewModels.Interfaces;
using Prism.Navigation;
using System.Threading.Tasks;

namespace DnnSummit.Manager.Interfaces
{
    public interface IErrorRetryManager
    {
        Task HandleRetryAsync(IHasDataRetrieval viewmodel, INavigationParameters parameters, int attempt = 0);
    }
}
