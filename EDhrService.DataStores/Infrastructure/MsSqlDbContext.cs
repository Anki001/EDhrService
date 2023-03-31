using Dapper;
using EDhrService.Common.Environment;
using EDhrService.Common.Interfaces;
using EDhrService.DataStores.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EDhrService.DataStores.Infrastructure
{
    public class MsSqlDbContext : Disposable, IDbContext
    {
        IApplicationConfiguration _applicationConfiguration;
        public MsSqlDbContext(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        SqlConnection _sqlConnection;
        SqlTransaction _sqlTransaction;
        public void BeginTransaction()
        {
            if (_sqlConnection == null)
            {
                Connect().Wait();
            }
            _sqlTransaction = _sqlConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _sqlTransaction?.Commit();
            _sqlTransaction = null;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<int> ExecuteCommandAsync(string sqlCommand, object parameters = null, bool doesSchemaExist = true)
        {
            return await ExecuteAction(() => _sqlConnection.ExecuteAsync(sqlCommand, parameters));
        }

        public async Task<int> ExecuteScalarAsync(string sqlCommand, object parameters = null, bool doesSchemaExist = true)
        {
            return await ExecuteAction(() => _sqlConnection.ExecuteScalarAsync<int>(sqlCommand, parameters));
        }

        public async Task<T> GetResultAsync<T>(string sqlCommand, object parameters = null, bool doesSchemaExist = true)
        {
            return await ExecuteAction(() => _sqlConnection.QuerySingleOrDefaultAsync<T>(sqlCommand, parameters));
        }

        public async Task<IEnumerable<T>> GetResultSetAsync<T>(string sqlCommand, object parameters = null, bool doesSchemaExist = true)
        {
            return await ExecuteAction(() => _sqlConnection.QueryAsync<T>(sqlCommand, parameters));
        }

        public void RemoveSavePoint(string name)
        {
            throw new NotImplementedException();
        }

        public void RollBack()
        {
            _sqlTransaction?.Rollback();
            _sqlTransaction = null;
        }

        public void RollbackSavePoint(string name)
        {
            throw new NotImplementedException();
        }

        public void SetSavePoint(string name)
        {
            throw new NotImplementedException();
        }
        protected override void OnDispose()
        {
            if (_sqlTransaction != null)
            {
                _sqlTransaction.Dispose();
                _sqlTransaction = null;
            }

            if (_sqlConnection != null)
            {
                if (_sqlConnection.State != ConnectionState.Closed)
                {
                    _sqlConnection.Close();
                }
                _sqlConnection = null;
            }
            base.OnDispose();
        }

        private async Task Connect()
        {
            if (_sqlConnection != null)
            {
                if (_sqlConnection.State == ConnectionState.Closed)
                {
                    _sqlConnection.Dispose();
                    _sqlConnection = null;
                }
                else
                {
                    return;
                }
            }

            _sqlConnection = new SqlConnection(_applicationConfiguration.Database.ConnectionString);

            await _sqlConnection.OpenAsync();
        }
        private async Task<T> ExecuteAction<T>(Func<Task<T>> execFunction)
        {
            int.TryParse(_applicationConfiguration.Database.MinRetries, out int maxRetries);
            var retriesPerform = 0;
            var result = default(T);

            while (retriesPerform < maxRetries)
            {
                retriesPerform++;
                try
                {
                    await Connect();
                    result = await execFunction();
                    return result;
                }
                catch (Exception)
                {
                    if (retriesPerform == maxRetries - 1)
                        throw;
                    Thread.Sleep(250); // All other errors, sleep for a bit
                }
                finally
                {
                    if (_sqlConnection.State == ConnectionState.Open)
                        _sqlConnection.Close();
                }
            }
            return result;
        }
    }
}
