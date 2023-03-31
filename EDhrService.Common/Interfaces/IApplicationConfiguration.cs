namespace FileMonitor.Common.Interfaces
{
    public interface IApplicationConfiguration
    {
        bool LogEnabled { get; set; }
        Database Database { get; set; }
    }
}
