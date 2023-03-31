using EDhrService.DataStores.Repositories;

namespace EDhrService.DataStores.Interfaces
{
    public interface IUnitOfWork
    {        
        StationInformationRepository StationInformationRepository { get; }        
    }
}
