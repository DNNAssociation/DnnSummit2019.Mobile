using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace DnnSummit.ViewModels
{
    public class LocationViewModel : BindableBase, INavigatingAware
    {
        public string Title => "Location";

        private LocationInfoViewModel _general;
        public LocationInfoViewModel General
        {
            get { return _general; }
            set
            {
                SetProperty(ref _general, value);
                RaisePropertyChanged(nameof(General));
            }
        }

        private LocationInfoViewModel _hotel;
        public LocationInfoViewModel Hotel
        {
            get { return _hotel; }
            set
            {
                SetProperty(ref _hotel, value);
                RaisePropertyChanged(nameof(Hotel));
            }
        }

        private LocationInfoViewModel _gettingThere;
        public LocationInfoViewModel GettingThere
        {
            get { return _gettingThere; }
            set
            {
                SetProperty(ref _gettingThere, value);
                RaisePropertyChanged(nameof(GettingThere));
            }
        }

        private LocationInfoViewModel _whatToDo;
        public LocationInfoViewModel WhatToDo
        {
            get { return _whatToDo; }
            set
            {
                SetProperty(ref _whatToDo, value);
                RaisePropertyChanged(nameof(WhatToDo));
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            General = new LocationInfoViewModel
            {
                ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/banner-denver.jpg",
                ImageTitle = "DENVER, CO",
                Title = "Embassy Suites",
                Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
            };
            Hotel = new LocationInfoViewModel
            {
                ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/embassy-suites.jpg",
                ImageTitle = "HOTEL & CONFERENCE",
                Title = "Ipsum Lorem",
                Description = "DNN Summit will be held at The Embassy Suites by Hilton Denver Downtown Convention Center and Hotel. A block of rooms has been reserved for February 17, 2019 - February 24, 2019.The special room rate will be available until January 18th or until the group block is sold -out, whichever comes first.Click Here to Book."
            };
            GettingThere = new LocationInfoViewModel
            {
                ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/map-image.jpg",
                ImageTitle = "GETTING THERE",
                Title = "Travel",
                Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
            };
            WhatToDo = new LocationInfoViewModel
            {
                ImageSource = "https://www.dnnsummit.org/Portals/0/Images/Summit2017/red-rocks.jpg",
                ImageTitle = "WHAT TO DO?",
                Title = "Things to do",
                Description = "DNN Summit will be held at Embassy Suites and Convention Center February 19–21, 2019. Embassy Suites is in the heart of downtown Denver, just steps away from restaurants, shopping malls, nightlife &amp; more."
            };

        }
    }
}
