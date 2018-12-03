using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class SessionService : ISessionService
    {
        public async Task<IEnumerable<Session>> GetAsync()
        {
            // TODO - Update this to query the DNN API from the DNN Summit Website
            await Task.Delay(1);
            return new[]
            {
                new Session
                {
                    Title = "DNN MVC Module Development",
                    Abstract = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website.",
                    Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                    Day = "Day 1",
                    TimeSlotName = "Session 1",
                    TimeSlot = "9:10 - 10:10",
                    Category = "Development",
                    Level = "Beginner",
                    Room = "Erie",
                    Speaker = new Speaker
                    {
                        Name = "Andrew Hoefling",
                        Twitter = "andrew_hoefling",
                        Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                        PhotoLink = "https://www.dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"                        
                    }
                },
                new Session
                {
                    Title = "DNN MVC Module Development",
                    Abstract = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website.",
                    Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                    Day = "Day 1",
                    TimeSlotName = "Session 2",
                    TimeSlot = "10:20 - 11:20",
                    Category = "Marketing",
                    Level = "Beginner",
                    Room = "Erie",
                    Speaker = new Speaker
                    {
                        Name = "Andrew Hoefling",
                        Twitter = "andrew_hoefling",
                        Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                        PhotoLink = "https://www.dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                    }
                },
                new Session
                {
                    Title = "DNN MVC Module Development",
                    Abstract = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website.",
                    Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                    Day = "Day 1",
                    TimeSlotName = "Session 1",
                    TimeSlot = "9:10 - 10:10",
                    Category = "Security",
                    Level = "Beginner",
                    Room = "Erie",
                    Speaker = new Speaker
                    {
                        Name = "Andrew Hoefling",
                        Twitter = "andrew_hoefling",
                        Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                        PhotoLink = "https://www.dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                    }
                },
                new Session
                {
                    Title = "DNN MVC Module Development",
                    Abstract = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website.",
                    Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                    Day = "Day 1",
                    TimeSlotName = "Session 1",
                    TimeSlot = "9:10 - 10:10",
                    Category = "UX Dev",
                    Level = "Beginner",
                    Room = "Erie",
                    Speaker = new Speaker
                    {
                        Name = "Andrew Hoefling",
                        Twitter = "andrew_hoefling",
                        Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                        PhotoLink = "https://www.dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                    }
                },
                new Session
                {
                    Title = "DNN MVC Module Development",
                    Abstract = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website.",
                    Description = "Developing a DNN Modules in MVC shouldn't be difficult, with the right tools and right understanding of the APIs you will be able to make compelling modules that can plug and play in any DNN Website. \r\nThere has been a lot of change in DNN in the past year and with that change there has been more power added to DNN MVC Modules. You can now write a DNN MVC Module that looks and feels very similar to an ASP.NET MVC website. Attendees will get a basic overview of how to build a DNN MVC application,how to handle routing between the different pages and how this scales to larger applications.",
                    Day = "Day 1",
                    TimeSlotName = "Session 2",
                    TimeSlot = "10:20 - 11:20",
                    Category = "DNN",
                    Level = "Beginner",
                    Room = "Erie",
                    Speaker = new Speaker
                    {
                        Name = "Andrew Hoefling",
                        Twitter = "andrew_hoefling",
                        Bio = "Andrew Hoefling is the Owner and Architect of Hoefling Software, LLC providing software consulting services for Web, Cloud, Desktop and Mobile development. He is experienced in enterprise software using C# and .NET which makes using DNN an easy choice for CMS projects. Andrew has been using DNN since the beginning of 2017 and as a new member to the community he has left an impact with several Pull Requests for the MVC platform. He received his bachelors from Rochester Institute of Technology and he was featured in the December 2017 DNN Digest.",
                        PhotoLink = "https://www.dnnsummit.org/Portals/0/Images/Summit2018/Speaker-Pics/Andrew-Hoefling.jpg"
                    }
                }
            };
        }
    }
}
