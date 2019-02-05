using DnnSummit.Data.Services.Interfaces;
using DnnSummit.Manager.Interfaces;
using DnnSummit.Models;
using DnnSummit.ViewModels.Interfaces;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.ViewModels
{
    public class FeedbackViewModel : BindableBase, INavigatingAware, IHasDataRetrieval
    {
        private IEnumerable<string> _endpoints;
        public string Title => "Feedback";
        protected IFeedbackService FeedbackService { get; }
        protected IFeedbackEndpointService FeedbackEndpointService { get; }
        protected IErrorRetryManager ErrorRetryManager { get; }
        public ObservableCollection<SurveyQuestion> Questions { get; }

        public FeedbackViewModel(
            IFeedbackService feedbackService,
            IFeedbackEndpointService feedbackEndpointService,
            IErrorRetryManager errorRetryManager)
        {
            FeedbackService = feedbackService;
            FeedbackEndpointService = feedbackEndpointService;
            ErrorRetryManager = errorRetryManager;
            Questions = new ObservableCollection<SurveyQuestion>();
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
                        Type = (Question)item.Type
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
