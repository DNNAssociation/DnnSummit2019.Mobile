using DnnSummit.Data.Extensions;
using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class SponsorService : BaseService<TwoSexyContent.Sponsor, Sponsor>, ISponsorService
    {
        public SponsorService() 
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetSponsors")
        {
        }

        protected override async Task<IEnumerable<Sponsor>> QueryAndMapAsync()
        {
            var sponsors = await QueryAsync();

            var results = new List<Task<Sponsor>>();
            foreach (var item in sponsors)
            {
                results.Add(Task.Run(new Func<Task<Sponsor>>(async () => new Sponsor
                {
                    Name = item.Title,
                    Homepage = item.Homepage,
                    Image = await GetImageFromUrlAsync($"https://www.dnnsummit.org{item.Image}"),
                    Level = item.Level.ToSponsorLevel()
                })));
            }

            return await Task.WhenAll(results);
        }
    }
}
