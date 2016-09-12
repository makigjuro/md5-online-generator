using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces;
using MD5OnlineGenerator.ServiceModel.Requests;
using MD5OnlineGenerator.ServiceModel.Responses;
using ServiceStack;

namespace MD5OnlineGenerator.ServiceInterface
{
    public class MD5Service : Service
    {
        private readonly IChecksumGenerator _checksumGenerator;
        private readonly IWebContentReader _webContentReader;

        public MD5Service(IChecksumGenerator checksumGenerator, IWebContentReader webContentReader)
        {
            _checksumGenerator = checksumGenerator;
            _webContentReader = webContentReader;
        }

        [AddHeader(ContentType = MimeTypes.Json)]
        public object Post(MD5Request request)
        {
            var decodedUrl = HttpUtility.UrlDecode(request.Url);

            var content =  _webContentReader.ReadContentFromWebSite(decodedUrl);

            var checksum =_checksumGenerator.CalculateHash(content);

            var result = new MD5Response() { Checksum = checksum };

            return new HttpResult(result, MimeTypes.Json);
        }
    }
}
