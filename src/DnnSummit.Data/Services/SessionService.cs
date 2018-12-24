using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class SessionService : BaseService<TwoSexyContent.Session, Session>, ISessionService
    {
        public SessionService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetSessions") { }
        protected override async Task<IEnumerable<Session>> QueryAndMapAsync()
        {
            var sessions = await QueryAsync();
            var speakers = await QueryAsync<TwoSexyContent.Speaker>("GetSpeakers");
            return sessions.Select(x => new Session
            {
                Title = x.Title,
                Abstract = x.Abstract,
                Description = x.Description,
                Day = x.Day,
                TimeSlot = x.TimeSlot,
                TimeSlotName = x.TimeSlot,
                VideoLink = x.VideoLink,
                Category = x.Category,
                Level = x.Level,
                Room = x.Room,
                Speaker = x.Speakers.Select(s => 
                    speakers
                    .Where(f => f.Id == s.Id)
                    .Select(m => new Speaker
                    {
                        Name = m.Title,
                        // TODO - update this to use new byte[]
                        //PhotoLink = $"https://www.dnnsummit.org{m.Photo}"
                    })
                    .FirstOrDefault()).FirstOrDefault() // remove last firstOrDefault when we update to array
            });
        }
    }
}
