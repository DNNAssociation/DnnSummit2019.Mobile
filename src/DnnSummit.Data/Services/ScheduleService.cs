using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class ScheduleService : BaseService<TwoSexyContent.Schedule>, IScheduleService
    {
        public ScheduleService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetSchedules") { }

        public async Task<IEnumerable<ScheduleDetails>> GetAsync()
        {
            var days = await QueryAsync();
            var sections = await QueryAsync<TwoSexyContent.Section>("GetContentSections");

            var data = new List<ScheduleDetails>();
            foreach (var day in days)
            {
                var publishedSections = new List<Content>();
                foreach (var item in day.Contents)
                {
                    var current = sections.FirstOrDefault(x => x.Id == item.Id);
                    if (current != null)
                    {
                        publishedSections.Add(new Content
                        {
                            Title = current.Title,
                            SubTitle = current.SubTitle,
                            SubTitleNormal = current.SubTitleNormal,
                            Heading = current.Heading,
                            Description = current.Content,
                            VideoLink = current.YouTubeLink,
                            VideoButtonTitle = current.YouTubeButtonTitle
                        });
                    }
                }

                data.Add(new ScheduleDetails
                {
                    Title = day.Title,
                    CardDescription = day.MobileAppTitle,
                    BannerTitle = day.BannerTitle,
                    BannerHeading = day.BannerHeading,
                    BannerImage = $"https://www.dnnsummit.org{day.BannerImage}",
                    Sections = publishedSections
                });
            }

            return data;
        }

        public async Task<ScheduleDetails> GetAsync(string day)
        {
            await Task.Delay(1);
            return new ScheduleDetails
            {
                BannerTitle = "BASE CAMP",
                BannerHeading = "ipsum lorem iopem",
                Sections = new[]
                {
                    new Content
                    {
                        Title = "Training Courses — All Day [$275 • Includes Breakfast Buffet & Lunch]",
                        Heading = "Tuesday Feb 19 — 2nd Floor in Silverton 1,2 & 3. Breakfast buffet and setup is at 8AM, courses are from 9AM to 5PM, Registration on 2nd Floor",
                        Description = "The first day of DNN Summit includes full training courses for: DNN Administration, DNN Theming/Skinning, DNN Development Intro and Advanced, and an Evoq/LiquidContent training session. These full-day sessions include all day refreshments, breakfast, lunch and a pass to the following days conference. Breakfast will be in the 2nd Floor Foyer & Lunch will be in the Cripple Creek Ballroom on the 2nd Floor."
                    },
                    new Content
                    {
                        Title = "DNN Help Lab — Morning [$150 (no food included)]",
                        Heading = "Tuesday Feb 19 — 3rd Floor in Crestone B from 9AM to 12PM, Registration on 2nd Floor",
                        Description = "This half-day of DNN support involves hands-on troubleshooting, support and development for your websites and module development projects."
                    },
                    new Content
                    {
                        Title = "Business Round Table — 1pm to 4pm [FREE & Open to All Conference Attendees]",
                        Heading = "Tuesday Feb 19 — 3rd Floor in Crestone B from 1pm to 5pm, Registration on 2nd Floor",
                        Description = "The Business Roundtable is an opportunity for structured conversation with a strong emphasis on interaction and community discussion. Presentations are limited to ‘setting the stage’ for discussions of business topics that affect issues addressed by various segments of the DNN Community.\r\n\r\nOne key focus of this year's DNN Summit Business Roundtable will be the discussion of \"What's Next for DNN?\" So be sure to bring your ideas, your feature requests and your excitement to help discuss the direction of new development and elements for DNN."
                    },
                    new Content
                    {
                        Title = "Welcome Reception - 7:30pm to 9:30pm [FREE & Open to All Conference Attendees]",
                        Heading = "Tuesday Feb 19 — Hotel Bar on Lobby Floor",
                        Description = "Training Day will be followed by a welcome party for all trainees and attendees. A cash bar will be available and socializing will continue into the night!"
                    }
                }
            };
    }
    }
}
