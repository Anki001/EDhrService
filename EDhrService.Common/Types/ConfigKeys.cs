using System;
using System.Collections.Generic;
using System.Text;

namespace FileMonitor.Common.Types
{
    public static class ConfigKeys
    {
        public const string LogEnabled = "App.LogEnabled";
        public static class Database
        {            
            public const string MinRetries = "Database.MinRetries";
            public const string SqlConnectionString = "Database.MinRetries";
        }
    }
}
