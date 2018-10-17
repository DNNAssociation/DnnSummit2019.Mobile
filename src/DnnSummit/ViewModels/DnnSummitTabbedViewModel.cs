using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class DnnSummitTabbedViewModel : BindableBase
    {
        protected IPageDialogService PageDialogService { get; }
        public DnnSummitTabbedViewModel(IPageDialogService pageDialogService)
        {
            PageDialogService = pageDialogService;

            Info = new DelegateCommand(OnInfo);
        }

        
        public ICommand Info { get; }

        private async void OnInfo()
        {
            await PageDialogService.DisplayAlertAsync("Not Implemented", "This feature is not implemented yet", "OK");
        }
    }
}
