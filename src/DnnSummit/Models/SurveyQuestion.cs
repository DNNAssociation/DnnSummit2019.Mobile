using Prism.Mvvm;
using Xamarin.Forms;

namespace DnnSummit.Models
{
    public class SurveyQuestion : BindableBase
    {
        public SurveyQuestion()
        {
            TextColor = (Color)App.Current.Resources["DarkBlue"];
        }

        public string Question { get; set; }
        public string HelpMessage { get; set; }
        public Question Type { get; set; }
        public bool IsRequired { get; set; }

        private Color _textColor;
        public Color TextColor
        {
            get { return _textColor; }
            set
            {
                SetProperty(ref _textColor, value);
                RaisePropertyChanged(nameof(TextColor));
            }
        }

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
