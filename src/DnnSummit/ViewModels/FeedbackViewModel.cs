using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
#if APPCENTER
using Microsoft.AppCenter;
#endif
using Newtonsoft.Json;
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
using Xamarin.Essentials;
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
        protected IEndpointService EndpointService { get; }
        public ICommand Submit { get; }
        public ObservableCollection<SurveyQuestion> Questions { get; }

        private bool _busy;
        public bool Busy
        {
            get { return _busy; }
            set
            {
                SetProperty(ref _busy, value);
                RaisePropertyChanged(nameof(Busy));
            }
        }

        public FeedbackViewModel(
            IPageDialogService pageDialogService,
            INavigationService navigationService,
            IFeedbackService feedbackService,
            IFeedbackEndpointService feedbackEndpointService,
            IErrorRetryManager errorRetryManager,
            IEndpointService endpointService)
        {
            PageDialogService = pageDialogService;
            NavigationService = navigationService;
            FeedbackService = feedbackService;
            FeedbackEndpointService = feedbackEndpointService;
            ErrorRetryManager = errorRetryManager;
            EndpointService = endpointService;
            Submit = new DelegateCommand(OnSubmit);
            Questions = new ObservableCollection<SurveyQuestion>();
        }

        private async void OnSubmit()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await PageDialogService.DisplayAlertAsync("No Internet", "Unable to submit feedback without internet, try finding a paper copy", "OK");
                return;
            }

            if (Busy) return;

            
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

            Busy = true;

            bool anyErrors = false;
            foreach (var endpoint in _endpoints)
            {
                try
                {
#if APPCENTER
                    var deviceId = await AppCenter.GetInstallIdAsync();
#endif
                    var model = new FeedbackPayload
                    {
                        Year = 2019,
#if APPCENTER
                        DeviceId = deviceId.ToString(),
#endif
                        SurveyAnswers = JsonConvert.SerializeObject(Questions.Select(x => new { x.Question, x.Answer }))
                    };

                    var isSuccessful = await EndpointService.PostAsync(endpoint, model);
                    if (!isSuccessful)
                    {
                        anyErrors = true;
                    }
                }
                catch (Exception ex)
                {
                    anyErrors = true;
                }
            }

            if (anyErrors)
            {
                Busy = false;
                await PageDialogService.DisplayAlertAsync("Unable to Submit", "Find event staff for paper survey", "OK");
                return;
            }

            var complete = new Complete
            {
                Message = "ipsum",
                Summary = "lorem"
            };

            var parameters = new NavigationParameters
            {
                { Constants.Navigation.Parameters.GoBackToRoot, true },
                { Constants.Navigation.Parameters.Title, "Survey" },
                { Constants.Navigation.Parameters.Complete, complete }
            };
            await NavigationService.NavigateAsync(Constants.Navigation.CompletePage, parameters);
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
                    var question = new SurveyQuestion
                    {
                        Question = item.Question,
                        HelpMessage = item.Help,
                        Type = (Question)item.Type,
                        IsRequired = item.IsRequired
                    };

                    if (question.Type == Question.CustomOptions)
                    {
                        foreach (var option in item.Options)
                        {
                            question.Options.Add(option);
                        }
                    }

                    Questions.Add(question);
                }
            }
            catch (Exception)
            {
                await ErrorRetryManager.HandleRetryAsync(this, parameters, attempt);
            }
        }
    }
}
