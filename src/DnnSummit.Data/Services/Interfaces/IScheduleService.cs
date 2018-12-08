using DnnSummit.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<ScheduleDetails> GetAsync(string day);
        Task<IEnumerable<ScheduleDetails>> GetAsync();
    }
}
