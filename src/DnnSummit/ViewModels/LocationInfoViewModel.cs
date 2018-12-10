using Prism.Mvvm;

namespace DnnSummit.ViewModels
{
    public class LocationInfoViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                SetProperty(ref _title, value);
                RaisePropertyChanged(nameof(Title));
            }
        }

        private string _imageSource;
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                SetProperty(ref _imageSource, value);
                RaisePropertyChanged(nameof(ImageSource));
            }
        }

        private string _imageTitle;
        public string ImageTitle
        {
            get { return _imageTitle; }
            set
            {
                SetProperty(ref _imageTitle, value);
                RaisePropertyChanged(nameof(ImageTitle));
            }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                SetProperty(ref _description, value);
                RaisePropertyChanged(nameof(Description));
            }
        }
    }
}
