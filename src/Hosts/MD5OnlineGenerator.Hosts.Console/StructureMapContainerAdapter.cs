using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Configuration;
using StructureMap;

namespace MD5OnlineGenerator.Hosts.Console
{
    public class StructureMapContainerAdapter : IContainerAdapter
    {
        public T TryResolve<T>()
        {
            return ObjectFactory.Container.TryGetInstance<T>();
        }

        public T Resolve<T>()
        {
            return ObjectFactory.Container.TryGetInstance<T>();
        }
    }
}
