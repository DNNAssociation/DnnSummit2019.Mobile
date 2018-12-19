using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class ScheduleService : BaseService<TwoSexyContent.Schedule, ScheduleDetails>, IScheduleService
    {
        public ScheduleService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetSchedules") { }

        protected override async Task<IEnumerable<ScheduleDetails>> QueryAndMapAsync()
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
    }
}
