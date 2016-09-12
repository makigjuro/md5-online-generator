using System.Configuration;

namespace MD5OnlineGenerator.BusinessLogic.Utilities
{
    public class AppConfigurationManager
    {
        public static string ClientApplicationVirtualPath => ConfigurationManager.AppSettings["ClientApplicationVirtualPath"];
        public static string ClientApplicationFolderPath => ConfigurationManager.AppSettings["ClientApplicationFolderPath"];
    }
}
