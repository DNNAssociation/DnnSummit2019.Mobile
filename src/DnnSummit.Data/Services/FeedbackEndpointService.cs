using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class FeedbackEndpointService : BaseService<TwoSexyContent.FeedbackEndpoint, FeedbackEndpoint>, IFeedbackEndpointService
    {
        public FeedbackEndpointService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetFeedbackEndpoints")
        {
        }

        protected override async Task<IEnumerable<FeedbackEndpoint>> QueryAndMapAsync()
        {
            var endpoints = await QueryAsync();
            return endpoints
                .Where(x => x.IsEnabled)
                .Select(x => new FeedbackEndpoint
                {
                    Route = x.Endpoint
                });
        }
    }
}
