using ServiceStack;

namespace MD5OnlineGenerator.ServiceModel.Responses
{
    public class MD5Response
    {
        public MD5Response()
        {
            ResponseStatus = new ResponseStatus();    
        }

        public string Checksum { get; set; }

        public ResponseStatus ResponseStatus { get; set; }
    }
}
