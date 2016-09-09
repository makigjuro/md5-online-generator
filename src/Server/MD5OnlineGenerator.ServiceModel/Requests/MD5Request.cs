using MD5OnlineGenerator.ServiceModel.Responses;
using ServiceStack;

namespace MD5OnlineGenerator.ServiceModel.Requests
{
    [Route("/md5/{Url}", "GET")]
    public class MD5Request : IReturn<MD5Response>
    {
        public string Url { get; set; }
    }
}
