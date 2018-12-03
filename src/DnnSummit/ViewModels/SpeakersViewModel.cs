using DnnSummit.Models;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace DnnSummit.ViewModels
{
    public class SpeakersViewModel : BindableBase, INavigatingAware
    {
        public string Title => "Speakers";

        public ObservableCollection<Speaker> Speakers { get; }

        public SpeakersViewModel()
        {
            Speakers = new ObservableCollection<Speaker>();
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
            });
            Speakers.Add(new Speaker
            {
                Name = "Andrew Hoefling",
                Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                HeadshotImage = "http://dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
            });
        }
    }
}
