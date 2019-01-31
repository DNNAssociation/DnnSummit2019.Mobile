using Prism.Navigation;
using System.Threading.Tasks;

namespace DnnSummit.ViewModels.Interfaces
{
    public interface IHasDataRetrieval
    {
        Task OnLoadAsync(INavigationParameters parameters, int attempt = 0);
    }
}
