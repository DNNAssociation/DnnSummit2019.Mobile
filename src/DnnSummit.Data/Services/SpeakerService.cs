using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class SpeakerService : BaseService<TwoSexyContent.Speaker, Speaker>, ISpeakerService
    {
        public SpeakerService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetSpeakers") { }
        protected override async Task<IEnumerable<Speaker>> QueryAndMapAsync()
        {
            var speakers = await QueryAsync();
            var sessions = (await QueryAsync<TwoSexyContent.Session>("GetSessions"))
                .ToDictionary(x => x.Id, x => x);

            var results = new List<Task<Speaker>>();
            foreach (var item in speakers)
            {
                results.Add(Task.Run(new Func<Task<Speaker>>(async () =>
                {
                    var current = new Speaker
                    {
                        Name = item.Title,
                        Bio = item.Bio,
                        Twitter = item.Twitter
                    };

                    var speakerSessions = new List<Session>();
                    foreach (var currentSession in item.Sessions)
                    {
                        if (sessions.ContainsKey(currentSession.Id))
                        {
                            var s = sessions[currentSession.Id];
                            speakerSessions.Add(new Session
                            {
                                Title = s.Title,
                                Abstract = s.Abstract,
                                Description = s.Description,
                                Day = s.Day,
                                TimeSlot = s.TimeSlot,
                                TimeSlotName = s.TimeSlot,
                                Category = s.Category,
                                VideoLink = s.VideoLink,
                                Level = s.Level,
                                Room = s.Room
                            });
                        }
                    }

                    current.Sessions = speakerSessions;
                    current.Photo = await GetImageFromUrlAsync($"https://www.dnnsummit.org{item.Photo}");
                    return current;
                })));
            }

            return Task.WhenAll(results).GetAwaiter().GetResult();
        }
    }
}
