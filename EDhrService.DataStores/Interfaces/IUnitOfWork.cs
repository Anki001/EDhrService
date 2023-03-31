using FileMonitor.DataStores.Repositories;

namespace FileMonitor.DataStores.Interfaces
{
    public interface IUnitOfWork
    {        
        StationInformationRepository StationInformationRepository { get; }        
    }
}
