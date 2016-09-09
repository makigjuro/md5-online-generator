using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5OnlineGenerator.BusinessLogic.Validation.Interfaces;

namespace MD5OnlineGenerator.BusinessLogic.Validation.Impl
{
    public class UrlValidator : IUrlValidator
    {
        public bool ValidUrl(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
