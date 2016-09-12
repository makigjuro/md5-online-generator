using System.IO;
using MD5OnlineGenerator.BusinessLogic.Utilities;
using ServiceStack;

namespace MD5OnlineGenerator.ServiceInterface
{
    public class FallBackService : Service
    {
        public object Any(FallbackForClientRoutes request)
        {
            return new HttpResult(new FileInfo($"{AppConfigurationManager.ClientApplicationFolderPath}index.html")) { ContentType = "text/html" };
        }
    }
}
