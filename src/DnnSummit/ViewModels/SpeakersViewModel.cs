using DnnSummit.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DnnSummit.ViewModels
{
    public class SpeakersViewModel : BindableBase, INavigatingAware
    {
        protected INavigationService NavigationService { get; }
        public string Title => "Speakers";

        public ObservableCollection<Speaker> Speakers { get; }
        public ICommand SessionSelected { get; }

        public SpeakersViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            Speakers = new ObservableCollection<Speaker>();
            SessionSelected = new DelegateCommand<Session>(OnSessionSelected);
        }

        private async void OnSessionSelected(Session session)
        {
            if (session != null)
            {
                var navigationParameter = new NavigationParameters()
                {
                    { nameof(Session), session }
                };
                await NavigationService.NavigateAsync(Constants.Navigation.SessionDetailsPage, navigationParameter);
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg",
                Sessions = new[]
                {
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    },
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    }
                }
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg",
                Sessions = new[]
                {
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    },
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    }
                }
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg",
                Sessions = new[]
                {
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    },
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    }
                }
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg",
                Sessions = new[]
                {
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    },
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    }
                }
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg",
                Sessions = new[]
                {
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    },
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    }
                }
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg",
                Sessions = new[]
                {
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    },
                    new Session
                    {
                        Title = "DNN MVC Module Development",
                        Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                        TimeSlotName = "Session 1",
                        TimeSlot = "9:10 - 10:10",
                        Track = SessionTrack.Development,
                        Room = "Erie",
                        Speaker = new Speaker
                        {
                            Name = "Andrew Hoefling",
                            Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                            HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                        }
                    }
                }
            });
        }
    }
}
