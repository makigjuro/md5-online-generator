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
        private static string readContents;

        public MD5Service(IChecksumGenerator checksumGenerator)
        {
            _checksumGenerator = checksumGenerator;
        }

        [AddHeader(ContentType = MimeTypes.Json)]
        public object Post(MD5Request request)
        {
            var decodedUrl = HttpUtility.UrlDecode(request.Url);

            var checksum =_checksumGenerator.CalculateHash(decodedUrl);
            var result = new MD5Response() { Checksum = checksum };

            return new HttpResult(result, MimeTypes.Json);
        }
    }
}
