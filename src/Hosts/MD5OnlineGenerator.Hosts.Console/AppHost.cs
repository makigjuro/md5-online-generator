using System;
using MD5OnlineGenerator.BusinessLogic.Utilities;
using MD5OnlineGenerator.BusinessLogic.Utilities.Impl;
using MD5OnlineGenerator.BusinessLogic.Utilities.Interfaces;
using MD5OnlineGenerator.BusinessLogic.Validation.Impl;
using MD5OnlineGenerator.BusinessLogic.Validation.Interfaces;
using MD5OnlineGenerator.ServiceInterface;
using ServiceStack;
using ServiceStack.Validation;
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
            ConfigureIoC(container);

            SetConfig(new HostConfig
            {
#if DEBUG
                DebugMode = true,
                WebHostPhysicalPath = AppConfigurationManager.ClientApplicationVirtualPath.MapServerPath(),
#endif
                HandlerFactoryPath = "api",
                AddRedirectParamsToQueryString = true,
            });

            //Config examples
            Plugins.Add(new ValidationFeature());
            Plugins.Add(new PostmanFeature());
            Plugins.Add(new CorsFeature());
        }

        //public override RouteAttribute[] GetRouteAttributes(Type requestType)
        //{
        //    var routes = base.GetRouteAttributes(requestType);
        //    routes.Each(x => x.Path = "/api" + x.Path);
        //    return routes;
        //}

        private void ConfigureIoC(Container container)
        {
            container.Adapter = new StructureMapContainerAdapter();

            //Register your dependencies
            container.RegisterValidators(typeof(MD5Validator).Assembly);

            ObjectFactory.Container.Inject(typeof(IChecksumGenerator), new MD5ChecksumGenerator());
            ObjectFactory.Container.Inject(typeof(IUrlValidator), new UrlValidator());
        }
    }
}
