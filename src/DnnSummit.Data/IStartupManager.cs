using DnnSummit.Data.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnnSummit.Data
{
    public interface IStartupManager
    {
        Task SyndDataAsync();
        IList<ISyncService> Services { get; }
    }
}
