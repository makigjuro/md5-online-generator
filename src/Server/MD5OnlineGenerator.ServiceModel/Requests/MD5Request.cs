using MD5OnlineGenerator.ServiceModel.Responses;
using ServiceStack;

namespace MD5OnlineGenerator.ServiceModel.Requests
{
    [Api("POST Url used in reading web site content and returns back a MD5 Checksum number")]
    [Route("/md5/", "POST")]
    public class MD5Request : IReturn<MD5Response>
    {
       // [EncodedParameter]
        public string Url { get; set; }
    }
}
