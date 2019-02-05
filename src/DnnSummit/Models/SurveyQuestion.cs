using Prism.Mvvm;

namespace DnnSummit.Models
{
    public class SurveyQuestion : BindableBase
    {
        public string Question { get; set; }
        public string HelpMessage { get; set; }
        public Question Type { get; set; }

        private string _answer;
        public string Answer
        {
            get { return _answer; }
            set
            {
                SetProperty(ref _answer, value);
                RaisePropertyChanged(nameof(Answer));
            }
        }
    }
}
