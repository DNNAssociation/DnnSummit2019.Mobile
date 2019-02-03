using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System;
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
            var timeslots = await QueryAsync<TwoSexyContent.TimeSlot>("GetTimeSlots");

            var results = new List<Task<Session>>();
            foreach (var item in sessions)
            {
                results.Add(Task.Run(new Func<Task<Session>>(async () =>
                {
                    int.TryParse(item.Day, out int day);
                    var currentTimeSlot = timeslots.FirstOrDefault(x => x.Id == item.Timeslots.FirstOrDefault().Id);
                    var current = new Session
                    {
                        Title = item.Title,
                        Abstract = item.Abstract,
                        Description = item.Description,
                        Day = day,
                        TimeSlot = currentTimeSlot?.Time,
                        TimeSlotName = currentTimeSlot?.Name,
                        VideoLink = item.VideoLink,
                        Category = item.Category,
                        Level = item.Level,
                        Room = item.Room,
                    };

                    var currentSpeakers = new List<Speaker>();
                    foreach (var itemSpeaker in item.Speakers
                        .Select(s => speakers.Where(f => f.Id == s.Id).FirstOrDefault()))
                    {
                        currentSpeakers.Add(new Speaker
                        {
                            Name = itemSpeaker.Title,
                            Photo = await GetImageFromUrlAsync($"https://www.dnnsummit.org{itemSpeaker.Photo}")
                        });
                    }

                    current.Speakers = currentSpeakers;

                    return current;
                })));
            }

            return await Task.WhenAll(results);
        }
    }
}
