using FileMonitor.Common.Models;
using FileMonitor.DataStores.Infrastructure;
using FileMonitor.DataStores.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileMonitor.DataStores.Repositories
{
    public class StationInformationRepository : BaseRepository, IRepository<AnkImage>
    {
        private readonly IDbContext _dbContext;
        public StationInformationRepository(IServiceProvider _serviceProvider) : base(_serviceProvider)
        {
            _dbContext = GetDbContext<MsSqlDbContext>();
        }

        public Task<int> AddOrUpdateAsync(AnkImage data)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AnkImage>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AnkImage> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AnkImage> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
