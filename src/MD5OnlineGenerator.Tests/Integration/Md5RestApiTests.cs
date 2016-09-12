using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5OnlineGenerator.Hosts.Console;
using MD5OnlineGenerator.ServiceModel.Requests;
using NUnit.Framework;
using ServiceStack;

namespace MD5OnlineGenerator.Tests.Integration
{
    [TestFixture]
    public class Md5RestApiTests
    {
        const string BaseUri = "http://localhost:3333/";

        ServiceStackHost appHost;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            //Start your AppHost on TestFixture SetUp
            appHost = new AppHost()
                .Init()
                .Start(BaseUri);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            //Dispose it on TearDown
            appHost.Dispose();
        }

        [Test]
        public void Check_For_Changes_In_Checksum()
        {
            var client = new JsonServiceClient(BaseUri);

            var url = "https://en.wikipedia.org/wiki/Static_web_page";

            var firstChecksumResponse = client.Post(new MD5Request() {Url = url});

            //make another call to the same url
            var secondChecksumResponse = client.Post(new MD5Request() { Url = url });

            Assert.AreEqual(firstChecksumResponse.Checksum, secondChecksumResponse.Checksum, "Provided MD5 checksums for the same url are not the same!");
        }
    }
}
