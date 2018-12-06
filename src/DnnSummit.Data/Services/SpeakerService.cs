using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class SpeakerService : BaseService<TwoSexyContent.Speaker>, ISpeakerService
    {
        public SpeakerService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetSpeakers") { }
        public async Task<IEnumerable<Speaker>> GetAsync()
        {
            var speakers = await QueryAsync();
            return speakers.Select(x => new Speaker
            {
                Name = x.Title,
                Bio = x.Bio,
                PhotoLink = $"https://www.dnnsummit.org{x.Photo}",
                Twitter = x.Twitter,
                Sessions = x.Sessions
                    .Select(s => new Session
                    {
                        Title = s.Title
                    })
            });
        }
    }
}
