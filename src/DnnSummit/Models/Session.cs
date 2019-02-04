using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace DnnSummit.Models
{
    public class Session : BindableBase
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

        private string _room;
        public string Room
        {
            get { return _room; }
            set
            {
                SetProperty(ref _room, value);
                RaisePropertyChanged(nameof(Room));
            }
        }

        private string _timeSlot;
        public string TimeSlot
        {
            get { return _timeSlot; }
            set
            {
                SetProperty(ref _timeSlot, value);
                RaisePropertyChanged(nameof(TimeSlot));
            }
        }

        private string _timeSlotName;
        public string TimeSlotName
        {
            get { return _timeSlotName; }
            set
            {
                SetProperty(ref _timeSlotName, value);
                RaisePropertyChanged(nameof(TimeSlotName));
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

        private SessionTrack _track;
        public SessionTrack Track
        {
            get { return _track; }
            set
            {
                SetProperty(ref _track, value);
                RaisePropertyChanged(nameof(Track));
            }
        }

        private IEnumerable<Speaker> _speakers;
        public IEnumerable<Speaker> Speakers
        {
            get { return _speakers; }
            set
            {
                SetProperty(ref _speakers, value);
                RaisePropertyChanged(nameof(Speakers));
            }
        }

        private bool _isFavorite;
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                SetProperty(ref _isFavorite, value);
                RaisePropertyChanged(nameof(IsFavorite));
            }
        }

        private string _videoLink;
        public string VideoLink
        {
            get { return _videoLink; }
            set
            {
                SetProperty(ref _videoLink, value);
                RaisePropertyChanged(nameof(VideoLink));
            }
        }

        private int _day;
        public int Day
        {
            get { return _day; }
            set
            {
                SetProperty(ref _day, value);
                RaisePropertyChanged(nameof(Day));
            }
        }
    }
}
