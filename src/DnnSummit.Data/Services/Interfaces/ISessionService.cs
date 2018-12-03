using DnnSummit.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DnnSummit.Data.Services.Interfaces
{
    public interface ISessionService
    {
        Task<IEnumerable<Session>> GetAsync();
    }
}
