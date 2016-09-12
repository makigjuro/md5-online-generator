using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces
{
    public interface IWebContentReader
    {
        string ReadContentFromWebSite(string url);
    }
}
