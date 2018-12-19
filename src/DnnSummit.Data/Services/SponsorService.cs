using DnnSummit.Data.Extensions;
using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
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
            return sponsors.Select(x => new Sponsor
            {
                Name = x.Title,
                Homepage = x.Homepage,
                ImageLink = $"https://www.dnnsummit.org{x.Image}",
                Level = x.Level.ToSponsorLevel()
            });
        }
    }
}
