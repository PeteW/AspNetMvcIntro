using System;
using System.Configuration;

namespace Acme.Portal.Core.Configuration
{
    public class SettingsManager
    {
        public static string MyAbilityConnectionString { get { return GetConnectionString("Db"); } }
        private static string GetAppSetting(string setting, string defaultValue)
        {
            try
            {
                return GetAppSetting(setting) ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        private static string GetConnectionString(string connectionStringName)
        {
            var test = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (test == null || string.IsNullOrEmpty(test.ConnectionString))
                throw new Exception(string.Format("The connection string [{0}] was empty or not found", connectionStringName));
            return test.ConnectionString;
        }

        private static string GetAppSetting(string setting)
        {
            var test = ConfigurationManager.AppSettings[setting];
            return test;
        }
    }
}