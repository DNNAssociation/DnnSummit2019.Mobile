using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DnnSummit.ViewModels
{
    public class LocationViewModel : BindableBase, INavigatingAware
    {
        public string Title => "Location";

        private IEnumerable<LocationInfoViewModel> _pages;
        public IEnumerable<LocationInfoViewModel> Pages
        {
            get { return _pages; }
            set
            {
                SetProperty(ref _pages, value);
                RaisePropertyChanged(nameof(Pages));
            }
        }

        public LocationViewModel()
        {
            Pages = new[]
            {
                new LocationInfoViewModel
                {
                    ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/banner-denver.jpg",
                    ImageTitle = "DENVER, CO",
                    Title = "Embassy Suites",
                    Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
                },
                new LocationInfoViewModel
                {
                    ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/embassy-suites.jpg",
                    ImageTitle = "HOTEL & CONFERENCE",
                    Title = "",
                    Description = "DNN Summit will be held at The Embassy Suites by Hilton Denver Downtown Convention Center and Hotel.\r\n\r\nA block of rooms has been reserved for February 17, 2019 - February 24, 2019. The special room rate will be available until January 18th or until the group block is sold-out, whichever comes first. Click Here to Book."
                },
                new LocationInfoViewModel
                {
                    ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/map-image.jpg",
                    ImageTitle = "GETTING THERE",
                    Title = "Travel",
                    Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
                },
                new LocationInfoViewModel
                {
                    ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/red-rocks.jpg",
                    ImageTitle = "WHAT TO DO?",
                    Title = "Things to do",
                    Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
                }
            };
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            // TODO - pull this from the dnn summit website
            //Pages = new[]
            //{
            //    new LocationInfoViewModel
            //    {
            //        ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/banner-denver.jpg",
            //        ImageTitle = "DENVER, CO",
            //        Title = "Embassy Suites",
            //        Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
            //    },
            //    new LocationInfoViewModel
            //    {
            //        ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/embassy-suites.jpg",
            //        ImageTitle = "HOTEL & CONFERENCE",
            //        Title = "",
            //        Description = "DNN Summit will be held at The Embassy Suites by Hilton Denver Downtown Convention Center and Hotel.\r\n\r\nA block of rooms has been reserved for February 17, 2019 - February 24, 2019. The special room rate will be available until January 18th or until the group block is sold-out, whichever comes first. Click Here to Book."
            //    },
            //    new LocationInfoViewModel
            //    {
            //        ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/map-image.jpg",
            //        ImageTitle = "GETTING THERE",
            //        Title = "Travel",
            //        Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
            //    },
            //    new LocationInfoViewModel
            //    {
            //        ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/red-rocks.jpg",
            //        ImageTitle = "WHAT TO DO?",
            //        Title = "Things to do",
            //        Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
            //    }
            //};
        }
    }
}
