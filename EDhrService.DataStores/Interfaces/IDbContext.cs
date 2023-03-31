using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace FileMonitor.DataStores.Interfaces
{
    public interface IDbContext : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollBack();
        void SetSavePoint(string name);
        void RemoveSavePoint(string name);
        void RollbackSavePoint(string name);
        Task<IEnumerable<T>> GetResultSetAsync<T>(string sqlCommand, object parameters = null, bool doesSchemaExist = true);
        Task<T> GetResultAsync<T>(string sqlCommand, object parameters = null, bool doesSchemaExist = true);
        Task<int> ExecuteCommandAsync(string sqlCommand, object parameters = null, bool doesSchemaExist = true);
        Task<int> ExecuteScalarAsync(string sqlCommand, object parameters = null, bool doesSchemaExist = true);
        //Task<DataTable> GetDbObjects(DbCollectionNames collectionName);
    }
}
