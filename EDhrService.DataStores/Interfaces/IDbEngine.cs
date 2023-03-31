using System.Data;

namespace EDhrService.DataStores.Interfaces
{
    public interface IDbEngine
    {
        IDbConnection Connect();
    }
}
