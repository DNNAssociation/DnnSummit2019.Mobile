using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class CreditService : BaseService<TwoSexyContent.Credit, Credit>, ICreditService
    {
        public CreditService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetCredits")
        {
        }

        protected override async Task<IEnumerable<Credit>> QueryAndMapAsync()
        {
            var credits = await QueryAsync();
            return await Task.WhenAll(credits.Select(async x => new Credit
            {
                Title = x.Title,
                CreditType = x.CreditType.ToLower() == "company" ? 1
                    : x.CreditType.ToLower() == "platform" ? 2 : 0,
                Description = x.Description,
                Website = x.Link,
                Logo = await GetImageFromUrlAsync(x.Logo)
            }));
        }
    }
}
