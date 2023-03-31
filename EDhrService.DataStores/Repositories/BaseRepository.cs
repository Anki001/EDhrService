using System;

namespace EDhrService.DataStores.Repositories
{
    public class BaseRepository
    {
        private readonly IServiceProvider _serviceProvider;

        protected BaseRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected T GetDbContext<T>() where T : class
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }
    }
}
