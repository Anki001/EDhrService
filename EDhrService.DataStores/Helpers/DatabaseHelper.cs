using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace FileWatcher.DataStores.Helpers
{
    public static class DatabaseHelper
    {
        public static string GetDatabaseSchemaName(string schemaName)
        {
            return string.IsNullOrWhiteSpace(schemaName) ? string.Empty : $"{schemaName}.";

        }
        public static string MsAccessConnectionString(string connectionString, string dbLocation, string dbName)
        {
            return connectionString.Replace("#DATASOURCE", string.Concat(dbLocation, dbName));
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }
}
