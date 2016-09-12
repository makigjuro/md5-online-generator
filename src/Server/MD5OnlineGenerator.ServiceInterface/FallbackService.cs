using System.IO;
using System.Net;
using MD5OnlineGenerator.BusinessLogic.Utilities;
using ServiceStack;

namespace MD5OnlineGenerator.ServiceInterface
{
    public class FallBackService : Service
    {
        public object Any(FallbackForClientRoutes request)
        {
            if (string.IsNullOrEmpty(request.PathInfo) || request.PathInfo == "/" || request.PathInfo == "favicon.ico")
            {
                // this is the default main page
                return new HttpResult(new FileInfo($"{AppConfigurationManager.ClientApplicationFolderPath}index.html")) { ContentType = "text/html" };
            }
            
            throw new HttpError(HttpStatusCode.NotFound);
        }
    }
}
