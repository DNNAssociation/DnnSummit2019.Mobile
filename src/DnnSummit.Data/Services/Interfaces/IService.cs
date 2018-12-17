using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services.Interfaces
{
    public interface IService<TModel> : ISyncService
    {
        Task<IEnumerable<TModel>> GetAsync(bool forceRefresh = false);
    }
}
