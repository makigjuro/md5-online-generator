﻿using System;
using System.Net;
using MD5OnlineGenerator.BusinessLogic.Utilities;
using MD5OnlineGenerator.BusinessLogic.Utilities.Impl;
using MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces;
using MD5OnlineGenerator.BusinessLogic.Validation.Impl;
using MD5OnlineGenerator.BusinessLogic.Validation.Interfaces;
using MD5OnlineGenerator.Hosts.Console.Utilities;
using MD5OnlineGenerator.ServiceInterface;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Host.Handlers;
using ServiceStack.Text;
using ServiceStack.Validation;
using ServiceStack.VirtualPath;
using StructureMap;
using Container = Funq.Container;

namespace MD5OnlineGenerator.Hosts.Console
{
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("MD5OnlineGenerator.Hosts.Console", typeof(MD5Service).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            JsConfig.EmitCamelCaseNames = true;

            ConfigureIoC(container);

            SetConfig(new HostConfig
            {
                DebugMode = true,
                WebHostPhysicalPath = AppConfigurationManager.ClientApplicationVirtualPath.MapServerPath(),
                HandlerFactoryPath = "api",
                AddRedirectParamsToQueryString = true,
            });

            CustomErrorHttpHandlers[HttpStatusCode.NotFound] = new CustomStaticFileHandler("/404.html");

            //Config examples
            Plugins.Add(new ValidationFeature());
            Plugins.Add(new PostmanFeature());
            Plugins.Add(new CorsFeature());
            Plugins.Add(new SwaggerFeature());
        }

        private void ConfigureIoC(Container container)
        {
            container.Adapter = new StructureMapContainerAdapter();

            //Register your dependencies
            container.RegisterValidators(typeof(MD5Validator).Assembly);

            ObjectFactory.Container.Inject(typeof(IChecksumGenerator), new MD5ChecksumGenerator());
            ObjectFactory.Container.Inject(typeof(IUrlValidator), new UrlValidator());
            ObjectFactory.Container.Inject(typeof(IWebContentReader), new WebContentReader());
        }
    }
}
