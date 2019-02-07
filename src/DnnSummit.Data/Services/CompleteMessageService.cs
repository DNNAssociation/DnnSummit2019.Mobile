using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class CompleteMessageService : BaseService<TwoSexyContent.CompleteMessage, CompleteMessage>, ICompleteMessageService
    {
        public CompleteMessageService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetCompleteMessages")
        {
        }

        protected override async Task<IEnumerable<CompleteMessage>> QueryAndMapAsync()
        {
            var messages = await QueryAsync();
            return messages.Select(x => new CompleteMessage
            {
                Title = x.Title,
                Message = x.Message
            });
        }
    }
}
