using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileMonitor.DataStores.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<int> AddOrUpdateAsync(TModel data);
        Task<IEnumerable<TModel>> GetAsync();
        Task<TModel> GetByNameAsync(string name);
        Task<TModel> GetByIdAsync(int id);
        Task<int> DeleteAsync(int id);
    }
}
