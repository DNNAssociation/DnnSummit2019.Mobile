using DnnSummit.Data.Services.Interfaces;
using Prism.Mvvm;

namespace DnnSummit.ViewModels
{
    public class FeedbackViewModel : BindableBase
    {
        public string Title => "Feedback";
        protected IFeedbackService FeedbackService { get; }
        protected IFeedbackEndpointService FeedbackEndpointService { get; }

        public FeedbackViewModel(
            IFeedbackService feedbackService,
            IFeedbackEndpointService feedbackEndpointService)
        {
            FeedbackService = feedbackService;
            FeedbackEndpointService = feedbackEndpointService;
        }
    }
}
