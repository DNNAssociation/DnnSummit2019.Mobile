using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DnnSummit.ViewModels
{
    public class FeedbackViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        private IEnumerable<string> _endpoints;
        public string Title => "Feedback";
        protected IPageDialogService PageDialogService { get; }
        protected INavigationService NavigationService { get; }
        protected IFeedbackService FeedbackService { get; }
        protected IFeedbackEndpointService FeedbackEndpointService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }
        public ICommand Submit { get; }
        public ObservableCollection<SurveyQuestion> Questions { get; }

        public FeedbackViewModel(
            IPageDialogService pageDialogService,
            INavigationService navigationService,
            IFeedbackService feedbackService,
            IFeedbackEndpointService feedbackEndpointService,
            IErrorRetryManager errorRetryManager)
        {
            PageDialogService = pageDialogService;
            NavigationService = navigationService;
            FeedbackService = feedbackService;
            FeedbackEndpointService = feedbackEndpointService;
            ErrorRetryManager = errorRetryManager;
            Submit = new DelegateCommand(OnSubmit);
            Questions = new ObservableCollection<SurveyQuestion>();
        }

        private async void OnSubmit()
        {
            var requiredQuestions = Questions.Where(x => x.IsRequired);
            if (requiredQuestions.Any(x => string.IsNullOrWhiteSpace(x.Answer)))
            {
                await PageDialogService.DisplayAlertAsync("Missing Fields", "Survey is incomplete, complete highlighted questions", "OK");

                foreach (var item in Questions.Where(x => x.IsRequired))
                {
                    item.TextColor = string.IsNullOrWhiteSpace(item.Answer) ?
                        Color.Red : (Color)App.Current.Resources["DarkBlue"];
                }

                return;
            }

            // TODO - POST Data
        }

        public async void OnNavigatingTo(INavigationParameters parameters)
        {
            await OnLoadAsync(parameters);
        }

        public async Task OnLoadAsync(INavigationParameters parameters, int attempt = 0)
        {
            try
            {
                var rawEndpoints = await FeedbackEndpointService.GetAsync();
                _endpoints = rawEndpoints.Select(x => x.Route);

                var rawQuestions = await FeedbackService.GetAsync();
                Questions.Clear();
                foreach (var item in rawQuestions)
                {
                    Questions.Add(new SurveyQuestion
                    {
                        Question = item.Question,
                        HelpMessage = item.Help,
                        Type = (Question)item.Type,
                        IsRequired = item.IsRequired
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
