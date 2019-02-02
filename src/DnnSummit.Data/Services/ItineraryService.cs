using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class ItineraryService : BaseService<TwoSexyContent.Itinerary, Itinerary>, IItineraryService
    {
        public ItineraryService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetItineraries")
        {
        }

        protected override async Task<IEnumerable<Itinerary>> QueryAndMapAsync()
        {
            var itineraries = await QueryAsync();
            var messages = await QueryAsync<TwoSexyContent.ItineraryMessage>("GetItineraryMessages");
            var events = await QueryAsync<TwoSexyContent.ItineraryEvent>("GetItineraryEvents");

            var items = new List<Itinerary>();
            foreach (var itinerary in itineraries)
            {
                items.Add(new Itinerary
                {
                    Title = itinerary.Title,
                    Retrieved = DateTime.Now,
                    Messages = messages
                        .Where(x => itinerary.Messages.Any(m => x.Id == m.Id))
                        .Select(x => new ItineraryMessage
                        {
                            Title = x.Title,
                            Heading = x.Heading,
                            SubHeading = x.SubHeading,
                            Events = events
                                .Where(e => x.Events.Any(y => e.Id == y.Id))
                                .Select(e => new ItineraryEvent
                                {
                                    Title = e.Title,
                                    TimeSlot = e.TimeSlot,
                                    Description = e.Description,
                                    Room = e.Room
                                })
                        })
                });
            }

            return items;
        }
    }
}
