using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Text;

namespace MD5OnlineGenerator.Hosts.Console
{
    class Program
    {
        private const string ListeningPort = "http://localhost:54236/";

        static void Main(string[] args)
        {
            new AppHost().Init().Start("http://*:54236/");
            $"ServiceStack Self Host with Razor listening at {ListeningPort}".Print();
            Process.Start(ListeningPort);

            System.Console.ReadLine();
        }
    }
}
