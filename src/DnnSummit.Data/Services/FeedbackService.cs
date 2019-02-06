using DnnSummit.Data.Models;
using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services
{
    internal class FeedbackService : BaseService<TwoSexyContent.Feedback, Feedback>, IFeedbackService
    {
        public FeedbackService()
            : base("https://www.dnnsummit.org/desktopmodules/2sxc/api/app/DnnSummit2019/Query/", "GetFeedbackQuestions")
        {
        }

        protected override async Task<IEnumerable<Feedback>> QueryAndMapAsync()
        {
            var questions = await QueryAsync();
            return questions
                .OrderBy(x => x.Order)
                .Select(x =>
                {
                    int.TryParse(x.Type, out int type);
                    return new Feedback
                    {
                        Question = x.Question,
                        Help = x.Help,
                        Type = type,
                        IsRequired = x.IsRequired
                    };
                });
        }
    }
}
