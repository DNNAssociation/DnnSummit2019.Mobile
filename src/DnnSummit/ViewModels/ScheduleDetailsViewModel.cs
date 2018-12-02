using DnnSummit.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace DnnSummit.ViewModels
{
    public class ScheduleDetailsViewModel : BindableBase, INavigatingAware
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

        private string _heading;
        public string Heading
        {
            get { return _heading; }
            set
            {
                SetProperty(ref _heading, value);
                RaisePropertyChanged(nameof(Heading));
            }
        }

        private string _subHeading;
        public string SubHeading
        {
            get { return _subHeading; }
            set
            {
                SetProperty(ref _subHeading, value);
                RaisePropertyChanged(nameof(SubHeading));
            }
        }

        public ObservableCollection<ScheduleContent> ContentSections { get; set; }

        public ScheduleDetailsViewModel()
        {
            ContentSections = new ObservableCollection<ScheduleContent>();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            bool isSuccessful = false;
            if (parameters.ContainsKey(nameof(Event)))
            {
                var details = (Event)parameters[nameof(Event)];
                if (details != null)
                {
                    Title = details.Title;
                    Description = details.Description;
                    Heading = "BASE CAMP";
                    SubHeading = "Ipsum lorem";

                    ContentSections.Add(new ScheduleContent
                    {
                        Title = "Training Courses — All Day [$275 • Includes Breakfast Buffet & Lunch]",
                        Heading = "Tuesday Feb 19 — 2nd Floor in Silverton 1,2 & 3. Breakfast buffet and setup is at 8AM, courses are from 9AM to 5PM, Registration on 2nd Floor",
                        Description = "The first day of DNN Summit includes full training courses for: DNN Administration, DNN Theming/Skinning, DNN Development Intro and Advanced, and an Evoq/LiquidContent training session. These full-day sessions include all day refreshments, breakfast, lunch and a pass to the following days conference. Breakfast will be in the 2nd Floor Foyer & Lunch will be in the Cripple Creek Ballroom on the 2nd Floor."
                    });
                    ContentSections.Add(new ScheduleContent
                    {
                        Title = "DNN Help Lab — Morning [$150 (no food included)]",
                        Heading = "Tuesday Feb 19 — 3rd Floor in Crestone B from 9AM to 12PM, Registration on 2nd Floor",
                        Description = "This half-day of DNN support involves hands-on troubleshooting, support and development for your websites and module development projects."
                    });
                    ContentSections.Add(new ScheduleContent
                    {
                        Title = "Business Round Table — 1pm to 4pm [FREE & Open to All Conference Attendees]",
                        Heading = "Tuesday Feb 19 — 3rd Floor in Crestone B from 1pm to 5pm, Registration on 2nd Floor",
                        Description = "The Business Roundtable is an opportunity for structured conversation with a strong emphasis on interaction and community discussion. Presentations are limited to ‘setting the stage’ for discussions of business topics that affect issues addressed by various segments of the DNN Community.\r\n\r\nOne key focus of this year's DNN Summit Business Roundtable will be the discussion of \"What's Next for DNN?\" So be sure to bring your ideas, your feature requests and your excitement to help discuss the direction of new development and elements for DNN."
                    });
                    ContentSections.Add(new ScheduleContent
                    {
                        Title = "Welcome Reception - 7:30pm to 9:30pm [FREE & Open to All Conference Attendees]",
                        Heading = "Tuesday Feb 19 — Hotel Bar on Lobby Floor",
                        Description = "Training Day will be followed by a welcome party for all trainees and attendees. A cash bar will be available and socializing will continue into the night!"
                    });

                    isSuccessful = true;
                }
            }

            if (!isSuccessful)
            {
                // display error page
            }
        }
    }
}
