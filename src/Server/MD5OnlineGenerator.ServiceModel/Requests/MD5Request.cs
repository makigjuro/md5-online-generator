using MD5OnlineGenerator.ServiceModel.Responses;
using ServiceStack;

namespace MD5OnlineGenerator.ServiceModel.Requests
{
    [Route("/md5/", "POST")]
    public class MD5Request : IReturn<MD5Response>
    {
       // [EncodedParameter]
        public string Url { get; set; }
    }
}
