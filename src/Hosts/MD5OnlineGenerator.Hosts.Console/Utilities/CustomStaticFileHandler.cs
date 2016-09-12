using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ServiceStack;
using ServiceStack.Host.Handlers;
using ServiceStack.Web;

namespace MD5OnlineGenerator.Hosts.Console.Utilities
{
    public class CustomStaticFileHandler : HttpAsyncTaskHandler
    {
        string filePath;
        public CustomStaticFileHandler(string filePath)
        {
            this.filePath = filePath;
        }

        public override void ProcessRequest(HttpContextBase context)
        {
            var httpReq = context.ToRequest(GetType().GetOperationName());
            ProcessRequest(httpReq, httpReq.Response, httpReq.OperationName);
        }

        public override void ProcessRequest(IRequest request, IResponse response,
            string operationName)
        {
            response.EndHttpHandlerRequest(skipClose: true, afterHeaders: r =>
            {
                var file = HostContext.VirtualPathProvider.GetFile(filePath);
                if (file == null)
                    throw new HttpException(404, "Not Found");

                r.SetContentLength(file.Length);
                var outputStream = r.OutputStream;
                using (var fs = file.OpenRead())
                {
                    fs.CopyTo(outputStream);
                    outputStream.Flush();
                }
            });
        }
    }

}
