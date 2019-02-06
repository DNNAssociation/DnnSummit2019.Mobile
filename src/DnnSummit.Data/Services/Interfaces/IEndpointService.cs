using System.Threading.Tasks;

namespace DnnSummit.Data.Services.Interfaces
{
    public interface IEndpointService
    {
        Task<bool> PostAsync<TRequest>(string route, TRequest input);
    }
}
