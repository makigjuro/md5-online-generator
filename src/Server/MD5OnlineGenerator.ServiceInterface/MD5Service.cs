using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces;
using MD5OnlineGenerator.ServiceModel.Requests;
using MD5OnlineGenerator.ServiceModel.Responses;
using ServiceStack;

namespace MD5OnlineGenerator.ServiceInterface
{
    public class MD5Service : Service
    {
        private readonly IChecksumGenerator _checksumGenerator;

        public MD5Service(IChecksumGenerator checksumGenerator)
        {
            _checksumGenerator = checksumGenerator;
        }

        public object Get(MD5Request request)
        {
            var checksum =_checksumGenerator.CalculateHash(request.Url);
            var result = new MD5Response() { Checksum = checksum };

            return new HttpResult(result, MimeTypes.Json);
        }

        public object Any(FallbackForClientRoutes request)
        {
            //Return default.html for unmatched requests so routing is handled on the client
            return new HttpResult
            {
                View = "/default.html"
            };
        }
    }
}
