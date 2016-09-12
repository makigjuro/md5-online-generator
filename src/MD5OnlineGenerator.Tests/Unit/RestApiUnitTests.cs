using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MD5OnlineGenerator.BusinessLogic.Utilities.Impl;
using MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces;
using MD5OnlineGenerator.BusinessLogic.Validation.Impl;
using MD5OnlineGenerator.BusinessLogic.Validation.Interfaces;
using MD5OnlineGenerator.Hosts.Console;
using MD5OnlineGenerator.ServiceInterface;
using MD5OnlineGenerator.ServiceModel.Requests;
using MD5OnlineGenerator.ServiceModel.Responses;
using Moq;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.Testing;
using ServiceStack.Validation;
using StructureMap;

namespace MD5OnlineGenerator.Tests.Unit
{
    [TestFixture]
    public class RestApiUnitTests
    {
        private ServiceStackHost appHost;

        private const string checksum = "746D0931605368989A20691A906A67F8";

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            appHost = new BasicAppHost(typeof(MD5Service).Assembly).Init();
            var container = appHost.Container;

            container.Adapter = new StructureMapContainerAdapter();

            //Register dependencies
            container.RegisterValidators(typeof(MD5Validator).Assembly);

            //create mocks
            var mockWebContentReader = new Mock<IWebContentReader>();
            mockWebContentReader.Setup(x => x.ReadContentFromWebSite("http://google.com"))
                .Returns("yadda yadda yadda");

            ObjectFactory.Container.Inject(typeof(IChecksumGenerator), new MD5ChecksumGenerator());
            ObjectFactory.Container.Inject(typeof(IUrlValidator), new UrlValidator());
            ObjectFactory.Container.Inject(typeof(IWebContentReader), mockWebContentReader.Object);
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void Return_CheckSum_From_Service()
        {
            var service = appHost.Container.Resolve<MD5Service>();

            var result = (HttpResult) service.Post(new MD5Request() { Url = "http://google.com"});

            var response = (MD5Response)result.Response;
            Assert.AreEqual(checksum, response.Checksum, "There is a problem with hashing content and generating checksum");
        }

        [Test]
        public void Service_Throws_Bad_Request()
        {
            var service = appHost.Container.Resolve<MD5Service>();

            Assert.Throws<HttpError>(() => service.Post(new MD5Request() {Url = "yadda yadda yadda"}));
        }

        [Test]
        public void Invalid_Url_To_Service()
        {
            var validateRunner = new MD5Validator(new UrlValidator());
            var result = validateRunner.Validate(new MD5Request() {Url = "yadda yadda yadda"});

            Assert.That(result.IsValid, Is.False);
        }
    }
}
