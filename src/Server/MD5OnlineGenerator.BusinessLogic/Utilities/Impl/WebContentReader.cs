using System;
using System.IO;
using System.Net;
using MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces;

namespace MD5OnlineGenerator.BusinessLogic.Utilities.Impl
{
    public class WebContentReader : IWebContentReader
    {
        public string ReadContentFromWebSite(string url)
        {
            var webRequest = WebRequest.Create(url);

            using (var response = webRequest.GetResponse())
            {
                using (var content = response.GetResponseStream())
                {
                    if (content == null)
                        throw new ArgumentNullException("Reading content from webSite doesn't return anything!");

                    using (var reader = new StreamReader(content))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
