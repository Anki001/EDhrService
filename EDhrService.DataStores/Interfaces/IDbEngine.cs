using System.Data;

namespace FileMonitor.DataStores.Interfaces
{
    public interface IDbEngine
    {
        IDbConnection Connect();
    }
}
