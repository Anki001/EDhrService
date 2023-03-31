using EDhrService.Common.Interfaces;
using EDhrService.Common.Types;
using System;
using System.Configuration;

namespace EDhrService.Common
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public ApplicationConfiguration()
        {
            LoadConfiguration();
        }

        public Database Database { get; set; }
        public bool LogEnabled { get; set; }

        private void LoadConfiguration()
        {
            LogEnabled = string.IsNullOrEmpty(ConfigurationManager.AppSettings[ConfigKeys.LogEnabled]) ?
               true :
               Convert.ToBoolean(ConfigurationManager.AppSettings[ConfigKeys.LogEnabled]);

            Database = new Database
            {                
                MinRetries = ConfigurationManager.AppSettings[ConfigKeys.Database.MinRetries],
                ConnectionString = ConfigurationManager.ConnectionStrings["Covidien"].ConnectionString,                
            };
        }

    }

    public class Database
    {
        public string MinRetries { get; set; }        
        public string ConnectionString { get; set; }        
    }
}
