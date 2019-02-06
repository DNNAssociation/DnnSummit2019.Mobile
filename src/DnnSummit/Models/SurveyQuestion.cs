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

        private string _question;
        public string Question
        {
            get { return _question; }
            set
            {
                SetProperty(ref _question, value);
                RaisePropertyChanged(nameof(Question));
            }
        }

        private string _helpMessage;
        public string HelpMessage
        {
            get { return _helpMessage; }
            set
            {
                SetProperty(ref _helpMessage, value);
                RaisePropertyChanged(nameof(HelpMessage));
            }
        }

        private Question _type;
        public Question Type
        {
            get { return _type; }
            set
            {
                if (value == Models.Question.Boolean)
                {
                    Answer = "false";
                }

                SetProperty(ref _type, value);
                RaisePropertyChanged(nameof(Type));
            }
        }

        private bool _isRequired;
        public bool IsRequired
        {
            get { return _isRequired; }
            set
            {
                SetProperty(ref _isRequired, value);
                RaisePropertyChanged(nameof(IsRequired));
            }
        }

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
